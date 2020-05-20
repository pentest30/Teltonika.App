using System;
using MediatR;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class TLMilestoneVehicleEvent:INotification
    {
        public double Milestone { get; set; }
        public DateTime EventUtc { get; set; }
        public Guid VehicleId { get; set; }

    }
}
