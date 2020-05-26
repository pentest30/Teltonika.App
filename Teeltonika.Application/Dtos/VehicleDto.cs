using System;
using Teltonika.Core.Domain.Customers.Vehicles;

namespace Teeltonika.Application.Dtos
{
    public class VehicleDto
    {
    
        public VehicleDto(Vehicle vehicle)
        {
            Id = vehicle.Id;
            VehicleName = vehicle.VehicleName;
            LicensePlate = vehicle.LicensePlate;
            Customer = vehicle.Customer?.Name;
            Vin = vehicle.Vin;
            InitServiceDate = vehicle.MileStoneUpdateUtc;
            VehicleStatus = vehicle.VehicleStatus.ToString();
            VehicleType = vehicle.VehicleType.ToString();
            if (vehicle.CreationDate != null) 
                CreatedDate = vehicle.CreationDate.Value;
        }

        public Guid Id { get; set; }
        public string VehicleName { get; set; }
        public string LicensePlate { get; set; }
        public string Customer { get; set; }
        public string Vin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime InitServiceDate { get; set; }
        public string VehicleStatus { get; set; }
        public string VehicleType { get; set; }

    }
}
