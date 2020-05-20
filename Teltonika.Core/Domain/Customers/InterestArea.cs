using System;

namespace Teltonika.Core.Domain.Customers
{
    public class InterestArea :BaseEntity
    {
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Radius { get; set; }
    }
}
