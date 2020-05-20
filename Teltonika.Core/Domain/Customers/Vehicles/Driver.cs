using System;
using System.Collections.Generic;

namespace Teltonika.Core.Domain.Customers.Vehicles
{
    public class Driver : BaseEntity
    {
        
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public DateTime? OnService { get; set; }
        public string DriverNumber{ get; set; }
        public Guid? InteerestAreaId { get; set; }
        public InterestArea InterestArea { get; set; }
    }
}
