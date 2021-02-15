using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary.VehicleEvent
{
    /// <summary>
    /// Class dedicated for non schaduled event of vehicle, for example damage.
    /// </summary>
    [Table("VehicleHistory")]
    public class VehicleHistory : IEquatable<VehicleHistory>, IComparable<VehicleHistory>
    {
        /// <summary>
        /// Property Id is dedicated for sql usage only for identity of Vehiclehistory Object.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        /// <summary>
        /// Property Vin is dedicated for sql usage only for identity of Vehicle Object.
        /// </summary>
        [Indexed]
        public string Vin { get; set; }
        /// <summary>
        /// Vehicle assigned to this event.
        /// </summary>
        [Ignore]
        public Vehicle Vehicle { get; set; }
        /// <summary>
        /// Description of event, for example: engine fail.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Property of date when event was.
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// ODO meter value when the event was.
        /// </summary>
        public uint VehicleKilometersValue { get; set; }
        /// <summary>
        /// Property DriverId is dedicated for sql usage only for identity of Driver.
        /// </summary>
        [Indexed]
        public uint DriverId { get; set; }
        /// <summary>
        /// Driver assigned to this event.
        /// </summary>
        [Ignore]
        public Driver Driver { get; set; }


        #region constructors
        /// <summary>
        /// Constructor without parameters for database use only.
        /// </summary>
        public VehicleHistory()
        {

        }
        public VehicleHistory(Vehicle vehicle, DateTime eventDate)
        {
            Vehicle = vehicle;
            EventTime = eventDate;
        }
        public VehicleHistory(Vehicle vehicle, DateTime eventDate, string eventDescription) : this (vehicle, eventDate)
        {
            Description = eventDescription;
        }
        public VehicleHistory(Vehicle vehicle, DateTime eventDate, Driver driver, string eventDescription) : this(vehicle, eventDate, eventDescription)
        {
            Driver = driver;
        }
        #endregion
        #region toString
        public override string ToString() => $"Event: {Description}:\nDate: {EventTime:d},Vehicle: {Vehicle.VehicleDescription}\nODOmeter Value: {VehicleKilometersValue};";
        #endregion
        #region Equals
        public bool Equals(VehicleHistory other)
        {
            if (other is null) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return (this.Vehicle==other.Vehicle&&this.Description==other.Description&&this.EventTime==other.EventTime&&this.VehicleKilometersValue==other.VehicleKilometersValue&&this.Driver==other.Driver);
        }
        public override bool Equals(object obj)
        {
            if (obj is VehicleHistory) return Equals((VehicleHistory)obj);
            else return false;
        }
        public static bool Equals (VehicleHistory v1, VehicleHistory v2)
        {
            if ((v1 is null) && (v2 is null)) return true;
            if (v1 is null) return false;
            return v1.Equals(v2);
        }
        public override int GetHashCode() => (this.Vehicle, this.Description, this.EventTime, this.VehicleKilometersValue,this.Driver).GetHashCode();
        #endregion
        #region Compare
        public int CompareTo(VehicleHistory other)
        {
            if (this.Equals(other)) return 0;
            return this.EventTime.CompareTo(other.EventTime);
        }
        #endregion

    }
}
