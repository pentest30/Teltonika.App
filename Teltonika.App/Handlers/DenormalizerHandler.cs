using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Teeltoonika.Protocol.Commands.Commands;
using Teltonika.App.Helpers;
using Teltonika.Core.Data;
using Teltonika.Core.Domain.Customers.Vehicles;
using Teltonika.Core.Domain.Gpsdevices;
using Teltonika.Core.Domain.Movement;

namespace Teltonika.App.Handlers
{
    public class DenormalizerHandler :
        AsyncRequestHandler<CreateBoxCommand>,
        INotificationHandler<TLGpsDataEvent>,
        INotificationHandler<TlFuelEevents>,
        INotificationHandler<TLExcessSpeedEvent>,
        INotificationHandler<TLEcoDriverAlertEvent>,
        INotificationHandler<TLMilestoneVehicleEvent>
    {
        private readonly ApplicationContext _context;
        public DenormalizerHandler()
        {
            _context  = new ApplicationContext(ConfigHelper.DbContextOptionsBuilder.Options);

        }

        public async Task Handle(TLGpsDataEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var box = await _context.Boxes
                    .SingleOrDefaultAsync(b => b.Imei == notification.Imei, cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                if (box != null)
                {

                    var position = new Position();
                    position.Box_Id = box?.Id;
                    position.Altitude = notification.Altitude;
                    position.Direction = notification.Direction;
                    position.Lat = notification.Lat;
                    position.Long = notification.Long;
                    position.Speed = notification.Speed;
                    position.Address = notification.Address;
                    position.Id = Guid.NewGuid();
                    position.Priority = notification.Priority;
                    position.Satellite = notification.Satellite;
                    position.Timestamp = notification.DateTimeUtc;
                    position.MotionStatus = notification.Speed > 0.0 ? notification.Speed > 8 ? MotionStatus.Moving :  MotionStatus.SlowMotion: MotionStatus.Stopped;
                    box.LastGpsInfoTime = notification.DateTimeUtc;
                    _context.Positions.Add(position);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
        }



        public async Task Handle(TlFuelEevents notification, CancellationToken cancellationToken)
        {
            var fuelRecordMsg = notification.Events.OrderBy(x => x.DateTimeUtc).Last();

            var lastRecord = await _context.FuelConsumptions.OrderByDescending(x => x.DateTimeUtc)
                // ReSharper disable once TooManyChainedReferences
                .FirstOrDefaultAsync(x => x.VehicleId == fuelRecordMsg.VehicleId, cancellationToken: cancellationToken).ConfigureAwait(false);
            var fuelConsumption = SetFuelConsumption(fuelRecordMsg);
            // ReSharper disable once ComplexConditionExpression
            if (lastRecord != null && fuelRecordMsg.MileStoneCalculated || lastRecord == null)
            {
                if (lastRecord != null)
                    fuelConsumption.Milestone += lastRecord.Milestone;
            }
            else if (!fuelRecordMsg.MileStoneCalculated)
                fuelConsumption.TotalFuelConsumed = fuelRecordMsg.FuelConsumption;

            _context.FuelConsumptions.Add(fuelConsumption);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        private static FuelConsumption SetFuelConsumption(TLFuelMilstoneEvent context)
        {
            var entity = new FuelConsumption();

            entity.VehicleId = context.VehicleId;
            entity.FuelUsed = context.FuelConsumption;
            entity.FuelLevel = context.FuelLevel;
            entity.Milestone = (int) context.Milestone;
            entity.CustomerId = context.CustomerId;
            entity.DateTimeUtc = context.DateTimeUtc;
            return entity;
        }
        public Task Handle(TLExcessSpeedEvent notification, CancellationToken cancellationToken)
        {
            _context.VehicleAlerts.Add(new VehicleAlert
            {
                Id = Guid.NewGuid(),
                VehicleEventType = notification.VehicleEventType,
                Speed = Convert.ToInt32(notification.Speed),
                EventUtc = notification.EventUtc,
                CustomerId = (Guid)notification.CustomerId,
                VehicleId = notification.VehicleId
            });
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task Handle(TLEcoDriverAlertEvent notification, CancellationToken cancellationToken)
        {
            _context.VehicleAlerts.Add(new VehicleAlert
            {
                Id = Guid.NewGuid(),
                VehicleEventType = notification.VehicleEventType,
                EventUtc = notification.EventUtc,
                CustomerId = (Guid)notification.CustomerId,
                VehicleId = notification.VehicleId
            });
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(TLMilestoneVehicleEvent notification, CancellationToken cancellationToken)
        {
            var vehicle = await _context.Vehicles.FindAsync(notification.VehicleId).ConfigureAwait(false);
            if (vehicle != null)
            {
                vehicle.Milestone +=(int) notification.Milestone;
                vehicle.MileStoneUpdateUtc = notification.EventUtc;
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            }
        }

        protected override async Task Handle(CreateBoxCommand request, CancellationToken cancellationToken)
        {
            var existingBox = await _context.Boxes.FirstOrDefaultAsync(b => b.Imei == request.Imei, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (existingBox != null)
                return;
            var box = new Box();
            box.Id = Guid.NewGuid();
            box.BoxStatus = BoxStatus.WaitPreparation;
            box.CreationDate = DateTime.UtcNow;
            box.Icci = String.Empty;
            box.PhoneNumber = String.Empty;
            box.Vehicle = null;
            box.Imei = request.Imei;
            box.SerialNumber = String.Empty;
            try
            {
                _context.Boxes.Add(box);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
        }
    }
}
