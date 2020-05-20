using System;
using System.Collections.Generic;

namespace Teltonika.Core.Domain.Customers.Vehicles
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public Nullable<System.Guid> Brand_Id { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
