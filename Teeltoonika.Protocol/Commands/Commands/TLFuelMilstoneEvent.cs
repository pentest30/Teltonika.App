using System;
using MediatR;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class TLFuelMilstoneEvent:INotification
    {
        public int FuelConsumption { get;  set; }
        public double Milestone { get;  set; }
        public DateTime DateTimeUtc { get;  set; }
        public int FuelLevel { get;  set; }
        public Guid VehicleId { get;  set; }
        public Guid CustomerId { get; set; }
        public bool MileStoneCalculated { get; set; }
    }
}