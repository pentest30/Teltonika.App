using System;

namespace Teltonika.Core.Domain.Customers.Driver.SocialData
{
    public class CardDriverActivity
    {
        public bool SlotOne { get; set; }
        public string CardNumber { get; set; }
        public bool CardPresent { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public DriverActivityType DriverActivityType { get; set; }
    }

    public enum DriverActivityType
    {
        Break,
        Available,
        Work,
        Driving
    }
}
