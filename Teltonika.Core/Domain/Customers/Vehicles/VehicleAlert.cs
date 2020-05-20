using System;

namespace Teltonika.Core.Domain.Customers.Vehicles
{
    public class VehicleAlert
    {
       // [Key]
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime EventUtc { get; set; }
        public VehicleEvent VehicleEventType { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Address { get; set; }
        public int Speed { get; set; }
    }
}
