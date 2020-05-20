using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Teeltoonika.Protocol.Commands.Commands;
using Teltonika.App.Helpers;
using Teltonika.Core.Data;
using Teltonika.Core.Domain.Customers.Vehicles;
using Teltonika.Core.Domain.Gpsdevices;
using Teltonika.Core.Geofence;
using Teltonika.Core.ReverseGeoCoding;

namespace Teltonika.App.Handlers
{
    public class TeltonikaHandler : INotificationHandler<TLGpsDataEvents>
    {
        private readonly ApplicationContext _dbContext;
        private readonly IMediator mediator;
        private readonly IMapper _mapper;
        private static SemaphoreSlim _semaphore;
        private readonly ReverseGeoCodingService _reverseGeoCodingService;

        public TeltonikaHandler(IMediator mediator, IMapper mapper, ReverseGeoCodingService reverseGeoCodingService)
        {
            _dbContext = new ApplicationContext(ConfigHelper.DbContextOptionsBuilder.Options);
            this.mediator = mediator;
            _mapper= mapper;
            _reverseGeoCodingService = reverseGeoCodingService;
            _semaphore = new SemaphoreSlim(1, 1);

        }
        private Task<Box> GetboxAsync(CreateTeltonikaGps command)
        {
            return _dbContext.Boxes.Include(x => x.Vehicle).FirstOrDefaultAsync(b => b.Imei == command.Imei);
        }

        private Task<PositionQuery> GetLastPositionAsync(Guid boxId)
        {
            return _dbContext.Positions.OrderByDescending(x => x.Timestamp).Where(x => x.Box_Id == boxId).Select(p => new PositionQuery() { VehicleId = p.Box.VehicleId, Lat = p.Lat, Long = p.Long }).FirstOrDefaultAsync();
        }
        public async Task Handle(TLGpsDataEvents notification, CancellationToken cancellationToken)
        {
            try
            {
                await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                var lastEvent = notification.Events.LastOrDefault();
                var box = await GetboxAsync(lastEvent).ConfigureAwait(false);
                List<TLEcoDriverAlertEvent> ecoDriveEvents = new List<TLEcoDriverAlertEvent>();
                List<TLGpsDataEvent> gpsDataEvents = new List<TLGpsDataEvent>();
                List<TLFuelMilstoneEvent> tlFuelMilstoneEvents = new List<TLFuelMilstoneEvent>();
                List<TLExcessSpeedEvent> speedEvents = new List<TLExcessSpeedEvent>();
                foreach (var teltonikaGps in notification.Events)
                {
                    if (box == null) continue;
                    // envoi des données GPs
                    var gpsDataEvent = _mapper.Map<TLGpsDataEvent>(teltonikaGps);
                    gpsDataEvent.BoxId = box.Id;
                    Trace.WriteLine(gpsDataEvent.DateTimeUtc + " lat:" + gpsDataEvent.Lat + " long:" + gpsDataEvent.Long);
                     //await mediator.Publish(gpsDataEvent).ConfigureAwait(false);
                    gpsDataEvents.Add(gpsDataEvent);

                    if (box.Vehicle == null) continue;
                    InitAllIoElements(teltonikaGps);
                    var canInfo = ProceedTNCANFilters(teltonikaGps);
                    if (canInfo != default(TLFuelMilstoneEvent))
                    {
                        canInfo.VehicleId = box.Vehicle.Id;
                        if (box.Vehicle.CustomerId.HasValue)
                            canInfo.CustomerId = box.Vehicle.CustomerId.Value;
                        // calcul de la distance par rapport au dernier point GPS
                        if (canInfo.Milestone <= 0)
                        {
                            var positionQuery = await GetLastPositionAsync(box.Id);
                            if (positionQuery != null)
                            {
                                var distance = GetGpsDistance(gpsDataEvents);
                                Trace.TraceInformation($"time :{gpsDataEvent.DateTimeUtc} Ditance: " + distance);
                                canInfo.Milestone = distance;
                                canInfo.MileStoneCalculated = true;
                                if (distance > 0 && box.VehicleId != null)
                                {
                                    await mediator.Publish(new TLMilestoneVehicleEvent
                                    {
                                        Milestone = distance,
                                        VehicleId = box.VehicleId.Value,
                                        EventUtc = teltonikaGps.DateTimeUtc
                                    }, cancellationToken).ConfigureAwait(false);
                                }
                            }
                        }
                        // await mediator.Publish(canInfo);
                        tlFuelMilstoneEvents.Add(canInfo);
                    }

                    // ReSharper disable once ComplexConditionExpression
                    if (box.Vehicle.SpeedAlertEnabled && box.Vehicle.MaxSpeed <= teltonikaGps.Speed
                        || teltonikaGps.Speed > 85)
                    {
                        var alertExeedSpeed = ProceedTLSpeedingAlert(teltonikaGps, box.Vehicle.Id,
                            box.Vehicle.CustomerId);
                        // await mediator.Publish(alertExeedSpeed);
                        speedEvents.Add(alertExeedSpeed);
                    }

                    var ecoDriveEvent = ProceedEcoDriverEvents(teltonikaGps, box.Vehicle.Id,
                        box.Vehicle.CustomerId);
                    if (ecoDriveEvent != default(TLEcoDriverAlertEvent))
                        //ecoDriveEvents.Add(ecoDriveEvent);
                        await mediator.Publish(ecoDriveEvent, cancellationToken).ConfigureAwait(false);
                }

                if (speedEvents.Any())
                    await mediator.Publish(speedEvents.OrderBy(x => x.EventUtc).LastOrDefault(), cancellationToken).ConfigureAwait(false);
                if (gpsDataEvents.Any())
                {

                    await GeoReverseCodeGpsDataAsync(gpsDataEvents).ConfigureAwait(false);
                    var gpSdata = gpsDataEvents.OrderBy(x => x.DateTimeUtc).LastOrDefault();
                    await mediator.Publish(gpSdata, cancellationToken).ConfigureAwait(false);
                }

                if (tlFuelMilstoneEvents.Any())
                {
                    var events = new TlFuelEevents
                    {
                        Id = Guid.NewGuid(),
                        Events = tlFuelMilstoneEvents,
                        //TlGpsDataEvents = gpsDataEvents
                    };
                    await mediator.Publish(events, cancellationToken).ConfigureAwait(false);

                }
                _semaphore.Release();

            }
            catch (Exception e)
            {
                Trace.TraceWarning(e.Message + " details:" + e.StackTrace);
                //throw;
            }
        }
        private static double GetGpsDistance(List<TLGpsDataEvent> gpsDataEvents)
        {
            var distance = 0.0;
            var firstPos = gpsDataEvents.First();
            foreach (var p in gpsDataEvents.Skip(1))
            {
                distance += Math.Round(GeofenceHelper.CalculateDistance(firstPos.Lat, firstPos.Long, p.Lat, p.Long), 2);
                firstPos = p;
            }

            return distance;
        }

        private async Task GeoReverseCodeGpsDataAsync(List<TLGpsDataEvent> gpsRessult)
        {
            var gpSdata = gpsRessult.OrderBy(x => x.DateTimeUtc).LastOrDefault();
           gpSdata.Address = await _reverseGeoCodingService.ReverseGoecodeAsync(gpSdata.Lat, gpSdata.Long).ConfigureAwait(false);

        }
        

        private static void InitAllIoElements(CreateTeltonikaGps context)
        {
            context.AllIoElements = new Dictionary<TNIoProperty, long>();
            foreach (var ioElement in context.IoElements_1B)
                context.AllIoElements.Add((TNIoProperty)ioElement.Key, ioElement.Value);
            foreach (var ioElement in context.IoElements_2B)
                context.AllIoElements.Add((TNIoProperty)ioElement.Key, ioElement.Value);
            foreach (var ioElement in context.IoElements_4B)
                context.AllIoElements.Add((TNIoProperty)ioElement.Key, ioElement.Value);
            foreach (var ioElement in context.IoElements_8B)
                context.AllIoElements.Add((TNIoProperty)ioElement.Key, ioElement.Value);
        }

        private TLFuelMilstoneEvent ProceedTNCANFilters(CreateTeltonikaGps data)
        {
            var fuelLevel = default(UInt32?);
            var milestone = default(UInt32?);
            var fuelUsed = default(UInt32?);
            if (data.AllIoElements != null &&
                data.AllIoElements.ContainsKey(TNIoProperty.High_resolution_total_vehicle_distance_X))
                milestone = Convert.ToUInt32(data.AllIoElements[TNIoProperty.High_resolution_total_vehicle_distance_X]);

            if (data.AllIoElements != null && data.AllIoElements.ContainsKey(TNIoProperty.Engine_total_fuel_used))
                fuelUsed = Convert.ToUInt32(data.AllIoElements[TNIoProperty.Engine_total_fuel_used]);

            if (data.AllIoElements != null && data.AllIoElements.ContainsKey(TNIoProperty.Fuel_level_1_X))
                fuelLevel = Convert.ToUInt32(data.AllIoElements[TNIoProperty.Fuel_level_1_X]);
            // ReSharper disable once ComplexConditionExpression
            if (fuelLevel != default(UInt32) && fuelLevel > 0 && fuelUsed > 0)
                return new TLFuelMilstoneEvent
                {
                    FuelConsumption = Convert.ToInt32(fuelUsed),
                    Milestone = Convert.ToInt32(milestone),
                    DateTimeUtc = data.DateTimeUtc,
                    FuelLevel = Convert.ToInt32(fuelLevel)
                };
            return default(TLFuelMilstoneEvent);
        }

        private TLExcessSpeedEvent ProceedTLSpeedingAlert(CreateTeltonikaGps data, Guid vehicleId, Guid? customerId)
        {
            return new TLExcessSpeedEvent
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                VehicleId = vehicleId,
                VehicleEventType = VehicleEvent.EXCESS_SPEED,
                EventUtc = data.DateTimeUtc,
                Latitude = (float?)data.Lat,
                Longitude = (float?)data.Long,
                Address = data.Address,
                Speed = data.Speed
            };


        }


        private TLEcoDriverAlertEvent ProceedEcoDriverEvents(CreateTeltonikaGps data, Guid vehicleId, Guid? customerId)
        {
            var @event = default(TLEcoDriverAlertEvent);
            if (data.DataEventIO == (int)TNIoProperty.Engine_speed_X)
                @event = new TLEcoDriverAlertEvent
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerId,
                    VehicleId = vehicleId,
                    VehicleEventType = VehicleEvent.EXCESS_ENGINE_SPEED,
                    EventUtc = data.DateTimeUtc,
                    Latitude = (float?)data.Lat,
                    Longitude = (float?)data.Long,
                    Address = data.Address
                    //Speed = data.Speed
                };
            else if (data.AllIoElements.ContainsKey(TNIoProperty.ECO_driving_type))
            {
                switch (Convert.ToByte(data.AllIoElements[TNIoProperty.ECO_driving_type]))
                {
                    case 1:
                        if (Convert.ToByte(data.AllIoElements[TNIoProperty.ECO_driving_value]) > 31)
                            @event = new TLEcoDriverAlertEvent
                            {
                                Id = Guid.NewGuid(),
                                CustomerId = customerId,
                                VehicleId = vehicleId,
                                VehicleEventType = VehicleEvent.EXCESS_ACCELERATION,
                                EventUtc = data.DateTimeUtc,
                                Latitude = (float?)data.Lat,
                                Longitude = (float?)data.Long,
                                Address = data.Address
                                //Speed = data.Speed
                            };
                        break;
                    case 2:
                        if (Convert.ToByte(data.AllIoElements[TNIoProperty.ECO_driving_value]) > 38)
                            @event = new TLEcoDriverAlertEvent
                            {
                                Id = Guid.NewGuid(),
                                CustomerId = customerId,
                                VehicleId = vehicleId,
                                VehicleEventType = VehicleEvent.SUDDEN_BRAKING,
                                EventUtc = data.DateTimeUtc,
                                Latitude = (float?)data.Lat,
                                Longitude = (float?)data.Long,
                                Address = data.Address
                                //Speed = data.Speed
                            };
                        break;
                    case 3:
                        if (Convert.ToByte(data.AllIoElements[TNIoProperty.ECO_driving_value]) > 45)
                            @event = new TLEcoDriverAlertEvent
                            {
                                Id = Guid.NewGuid(),
                                CustomerId = customerId,
                                VehicleId = vehicleId,
                                VehicleEventType = VehicleEvent.FAST_CORNER,
                                EventUtc = data.DateTimeUtc,
                                Latitude = (float?)data.Lat,
                                Longitude = (float?)data.Long,
                                Address = data.Address
                                //Speed = data.Speed
                            };
                        break;
                    default:
                        break;

                }
            }
            return @event;
        }

    }
    internal class PositionQuery
    {
        public Guid? VehicleId { get; set; }
        public double Lat { get; internal set; }
        public double Long { get; internal set; }
    }
}
