using System;

namespace Teltonika.Core.Domain.Customers.Driver
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
