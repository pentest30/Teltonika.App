using System.Collections.Generic;
using Teltonika.Core.Domain.Customers.Vehicles;
using Teltonika.Core.Domain.Users;

namespace Teltonika.Core.Domain.Customers
{
    public class Customer:BaseEntity
    {
        public Customer()
        {
          //  this.Boxes = new List<Box>();
            Users = new List<UserApp>();
            Vehicles = new List<Vehicle>();
            Areas = new List<InterestArea>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public System.DateTime? CreationDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
       // public virtual ICollection<Box> Boxes { get; set; }
        public  ICollection<UserApp> Users { get; set; }
        public  ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<InterestArea> Areas { get; set; }
    }
}
