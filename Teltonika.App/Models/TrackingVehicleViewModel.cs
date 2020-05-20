using System;

namespace Teltonika.App.Models
{
    public class TrackingVehicleViewModel
    {
        public short Altitude { get; set; }
        public short Direction { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public byte Priority { get; set; }
        public byte Satellite { get; set; }
        public double Speed { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public string Status { get; set; }
        public bool StopFlag { get; set; }
        public bool IsStop { get; set; }
        public string Alarm { get; set; }
        public int Mileage { get; set; }
        public int Temprature { get; set; }
        public string Address { get; set; }
        public string Imei { get; set; }

    }
}
