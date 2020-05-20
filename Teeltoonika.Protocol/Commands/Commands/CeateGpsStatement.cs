using System;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class CeateGpsStatement
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public DateTime TimeStampUtc { get; set; }
        public string IMEI { get; set; }
        public string SerialNumber { get; set; }
        public int Angle { get; set; }
        public double Heading { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public double Direction { get; set; }
        public string CustomerName { get; set; }
    }
}
