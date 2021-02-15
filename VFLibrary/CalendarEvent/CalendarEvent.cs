using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary.CalendarEvent
{
    /// <summary>
    /// Class dedicated for schaduled event of vehicle. It's kind of "to do" or reminder class of objects.
    /// </summary>
    [Table("VehicleCalendarEvents")]
    public class CalendarEvent : IEquatable<CalendarEvent>, IComparable<CalendarEvent>
    {
        /// <summary>
        /// Property Id is dedicated for sql usage only for identity of CalendarEvent Object.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        /// <summary>
        /// Property Vin is dedicated for sql usage only for identity of Vehicle Object.
        /// </summary>
        [Indexed]
        public string Vin { get; set; }
        /// <summary>
        /// Vehicle assigned to Calendar Event Object (schadule event).
        /// </summary>
        [Ignore]
        public Vehicle Vehicle { get; set; }
        /// <summary>
        /// Property DriverId is dedicated for sql usage only for identity of Driver.
        /// </summary>
        [Indexed]
        public uint DriverId { get; set; }
        /// <summary>
        /// Driver assigned to Calendar Event Object (schadule event).
        /// </summary>
        [Ignore]
        public Driver Driver { get; set; }
        /// <summary>
        /// Property of date when event is schaduled.
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// Description of event, for example: pay for vehicle insurance.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Default it's false because schaduled event's not done. When schaduled event's done set it true.
        /// </summary>
        public bool IsDone { get; set; } = false;

        #region constructors
        /// <summary>
        /// Constructor without parameters for database use only.
        /// </summary>
        public CalendarEvent()
        {

        }
        public CalendarEvent(Vehicle vehicle, DateTime eventDate)
        {
            this.Vehicle = vehicle;
            this.EventTime = eventDate;
        }

        public CalendarEvent(Vehicle vehicle, DateTime eventDate, string eventDescription) : this(vehicle, eventDate)
        {
            this.Description = eventDescription;
        }
        public CalendarEvent(Vehicle vehicle, DateTime eventDate, Driver driver, string eventDescription) : this(vehicle, eventDate, eventDescription)
        {
            this.Driver = driver;
        }

        #endregion
        #region toString
        public override string ToString() => $"Event: {Description}:\nDate: {EventTime:d},Vehicle: {Vehicle.VehicleDescription};";
        #endregion
        #region equals
        public bool Equals(CalendarEvent other)
        {
            if (other is null) return false;
            if (object.ReferenceEquals(this, other)) return true;
            return (this.Vehicle == other.Vehicle && this.Driver == other.Driver && this.EventTime == other.EventTime && this.Description == other.Description && this.IsDone == other.IsDone);
        }
        public override bool Equals(object obj)
        {
            if (obj is CalendarEvent) return Equals((CalendarEvent)obj);
            else return false;
        }
        public static bool Equals (CalendarEvent c1, CalendarEvent c2)
        {
            if ((c1 is null) && (c2 is null)) return true;
            if (c1 is null) return false;
            return c1.Equals(c2);
        }
        public override int GetHashCode() => (this.Vehicle, this.Driver, this.EventTime, this.Description, this.IsDone).GetHashCode();
        #endregion
        #region compare
        public int CompareTo(CalendarEvent other)
        {
            if (this.Equals(other)) return 0;
            return this.EventTime.CompareTo(other.EventTime);
        }
        #endregion
    }
}
