using System;
using Teltonika.Core.Domain.Customers.Vehicles;

namespace Teltonika.Core.Domain.Customers.SocialData
{
    public class Identifier : BaseEntity
    {

        public Guid? DriverId { get; set; }
        public string CardNumber { get; set; }
        public Driver Driver { get; set; }
        public DateTime CardIssueDate { get; set; }
        public DateTime CardValidityBegin { get; set; }
        public DateTime CardExpiryDate { get; set; }
    }
}
