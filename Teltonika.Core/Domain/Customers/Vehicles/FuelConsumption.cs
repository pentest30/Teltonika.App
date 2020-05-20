using System;

namespace Teltonika.Core.Domain.Customers.Vehicles
{
    public class FuelConsumption : BaseEntity
    {
         public int Milestone { get; set; }
        public int TotalFuelConsumed { get; set; }
        public Guid VehicleId { get; set; }
        public int FuelUsed { get; set; }
        public int FuelLevel { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime DateTimeUtc { get; set; }
    }
}
