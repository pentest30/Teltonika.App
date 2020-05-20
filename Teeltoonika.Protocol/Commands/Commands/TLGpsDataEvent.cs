using System;
using MediatR;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class TLGpsDataEvent :INotification
    {
        public Guid BoxId { get; set; }
        public DateTime DateTimeUtc { get;  set; }
        public short Altitude { get; set; }
        public short Direction { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public byte Priority { get; set; }
        public byte Satellite { get; set; }
        public double Speed { get; set; }
        public string Status { get; set; }
        public string Imei { get; set; }
        public string Address { get; set; }
    }
}