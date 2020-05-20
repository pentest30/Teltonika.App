using System;
using System.Collections.Generic;
using Teltonika.Core.Domain.EcoDrive;
using Teltonika.Core.Domain.Gpsdevices;

namespace Teltonika.Core.Domain.Customers.Vehicles
{
    public sealed class Vehicle:BaseEntity
    {
        public Guid? Brand_Id { get; set; }
        public Guid? Model_Id { get; set; }

        public Vehicle()
        {
            this.Boxes = new List<Box>();
        }

        public string VehicleName { get; set; }
        public string Vin { get; set; }
        public string LicensePlate { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> InitServiceDate { get; set; }
        public VehicleType VehicleType { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public ICollection<Box> Boxes { get; set; }
        public Customer Customer { get; set; }
        //[ForeignKey("Brand_Id")]
        public Brand Brand { get; set; }
        //[ForeignKey("Model_Id")]
        public Model Model { get; set; }
        public int MaxSpeed { get; set; }
        public int Milestone { get; set; }
        //[NotMapped]
        public Guid? Box_Id { get; set; }
        public Guid? InteerestAreaId { get; set; }
        public InterestArea InterestArea { get; set; }
        public ICollection<Driver> Drivers { get; set; }
        public ICollection<VehicleAlarrm> Alarrms { get; set; }
        public bool SpeedAlertEnabled { get; set; }
        public DateTime MileStoneUpdateUtc { get; set; }
    }
}
