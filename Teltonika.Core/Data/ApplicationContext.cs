
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teltonika.Core.Domain.Customers;
using Teltonika.Core.Domain.Customers.Vehicles;
using Teltonika.Core.Domain.Gpsdevices;
using Teltonika.Core.Domain.Movement;
using Teltonika.Core.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Teltonika.Core.Domain.Customers.Driver;

namespace Teltonika.Core.Data
{
    public class ApplicationContext : IdentityDbContext<UserApp, IdentityRole<Guid>, Guid>
    {
        public ApplicationContext(DbContextOptions settings) : base(settings){}
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<UserApp> UserAccounts { get; set; }
        public DbSet<InterestArea> InterestAreas { get; set; }
        public DbSet<VehicleAlert> VehicleAlerts { get; set; }
        public DbSet<FuelConsumption> FuelConsumptions { get; set; }
      
    }
}
