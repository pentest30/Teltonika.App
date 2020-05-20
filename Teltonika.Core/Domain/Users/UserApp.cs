using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Teltonika.Core.Domain.Customers;

namespace Teltonika.Core.Domain.Users
{
    public class UserApp : IdentityUser<Guid>
    {
        

        public string Tel { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public  Customer Customer { get; set; }
        public string TimeZoneInfo { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [NotMapped]
        public string Password { get; set; }

        // public IdentityRole Role { get; set; }
    }
}
