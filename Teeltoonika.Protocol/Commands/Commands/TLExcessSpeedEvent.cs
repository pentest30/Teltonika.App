using System;
using MediatR;
using Teltonika.Core.Domain.Customers.Vehicles;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class TLExcessSpeedEvent :INotification
    {
        public VehicleEvent VehicleEventType { get;  set; }
        public float? Latitude { get;  set; }
        public float? Longitude { get;  set; }
        public string Address { get;  set; }
        public DateTime EventUtc { get;  set; }
        public Guid VehicleId { get;  set; }
        public Guid? CustomerId { get; set; }
        public Guid Id { get; set; }
        public double Speed { get; set; }
    }
}