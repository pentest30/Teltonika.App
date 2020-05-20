using System;
using Teltonika.Core.Domain.Customers.Vehicles;

namespace Teltonika.Core.Domain.EcoDrive
{
    public class VehicleAlarrm: BaseEntity
    {
        public Guid? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime AlarmTime { get; set; }
        public AlarmType AlarmType { get; set; }
    }
}
