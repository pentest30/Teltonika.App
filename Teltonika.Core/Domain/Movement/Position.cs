using System;
using Teltonika.Core.Domain.Customers.Vehicles;
using Teltonika.Core.Domain.Gpsdevices;

namespace Teltonika.Core.Domain.Movement
{
    public class Position : BaseEntity
    {
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// <value>
        /// The altitude.
        /// </value>
        public short Altitude { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public short Direction { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>
        /// The lat.
        /// </value>
        public double Lat { get; set; }

        /// <summary>
        /// Gets or sets the long.
        /// </summary>
        /// <value>
        /// The long.
        /// </value>
        public double Long { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        public byte Priority { get; set; }

        /// <summary>
        /// Gets or sets the satellite.
        /// </summary>
        /// <value>
        /// The satellite.
        /// </value>
        public byte Satellite { get; set; }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// The speed.
        /// </value>
        public double Speed { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the box identifier.
        /// </summary>
        /// <value>
        /// The box identifier.
        /// </value>
        //[Index("IX_Box_Id")] 
        public Nullable<System.Guid> Box_Id { get; set; }

        /// <summary>
        /// Gets or sets the box.
        /// </summary>
        /// <value>
        /// The box.
        /// </value>
        public virtual Box Box { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [stop flag].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [stop flag]; otherwise, <c>false</c>.
        /// </value>
        public bool StopFlag { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is stop.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is stop; otherwise, <c>false</c>.
        /// </value>
        public bool IsStop { get; set; }
        /// <summary>
        /// Gets or sets the acceleration.
        /// </summary>
        /// <value>
        /// The acceleration.
        /// </value>
        public Acceleration Acceleration { get; set; }
        /// <summary>
        /// Gets or sets the door status.
        /// </summary>
        /// <value>
        /// The door status.
        /// </value>
        public DoorStatus DoorStatus { get; set; }
        /// <summary>
        /// Gets or sets the mileage.
        /// </summary>
        /// <value>
        /// The mileage.
        /// </value>
        public int Mileage { get; set; }

        /// <summary>
        /// Gets or sets the greedriving.
        /// </summary>
        /// <value>
        /// The greedriving.
        /// </value>
        public GreedyDriving GreedyDriving { get; set; }
        /// <summary>
        /// address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// region
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// state
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// motion status
        /// </summary>
        public MotionStatus MotionStatus { get; set; }
        //[NotMapped]
        public Vehicle Vehicle { get; set; }
    }
}
