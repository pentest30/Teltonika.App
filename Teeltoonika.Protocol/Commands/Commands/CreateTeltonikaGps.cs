using System;
using System.Collections.Generic;
using MediatR;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class CreateTeltonikaGps :INotification
    {
        public CreateTeltonikaGps()
        {
            IoElements_1B = new Dictionary<byte, long>();
            IoElements_2B = new Dictionary<byte, long>();
            IoElements_4B = new Dictionary<byte, long>();
            IoElements_8B = new Dictionary<byte, long>();
        }
        public string Imei { get; set; }
       // [JsonConverter(typeof(JsonDictionaryAttribute))]
        public Dictionary<byte, long> IoElements_8B;
        public byte EventIoElementId;
       // [JsonConverter(typeof(JsonDictionaryAttribute))]
        public Dictionary<byte, long> IoElements_1B;
      //  [JsonConverter(typeof(JsonDictionaryAttribute))]
        public Dictionary<byte, long> IoElements_2B;
       // [JsonConverter(typeof(JsonDictionaryAttribute))]
        public Dictionary<byte, long> IoElements_4B;
        public int DataEventIO;
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
        public Dictionary<TNIoProperty, long> AllIoElements { get; set; }
    }
}
