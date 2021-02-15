using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary
{
    /// <summary>
    /// Vehicle class. In this class you can create Vehicle object and attached to it Driver objerct.
    /// </summary>
    [Table("Vehicles")]
    public class Vehicle : IEquatable<Vehicle>
    {
        /// <summary>
        /// Most fundamental idefitier of vehicle. It's Vehicle Identification Number and every car has it from manufacture.
        /// </summary>
        [PrimaryKey]
        public string Vin { get; set; }
        /// <summary>
        /// Second important identifier of car.
        /// </summary>
        [Unique]
        public string VehiclePlate { get; set; }
        /// <summary>
        /// It's description for user for easily identify of vehicle. You can set for example manufacture and model name, for example "Tesla Model S, the red one"
        /// </summary>
        public string VehicleDescription { get; set; }
        /// <summary>
        /// set purchase date only if you need it
        /// </summary>
        public DateTime PurchaseDate{ get; set; }
        /// <summary>
        /// set InitialKilometersValue only if you need it
        /// </summary>
        public int InitialKilometersValue { get; set; }
        /// <summary>
        /// set as IsActive(false) in end of usage of vehilce, for example if you sold it
        /// </summary>
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// DriverID is for sql usage only for identify of Driver
        /// </summary>
        [Indexed]
        public uint DriverID { get; set; }
        /// <summary>
        /// Driver assign to vehicle.
        /// </summary>
        [Ignore]
        public Driver Driver { get; set; }
        #region constructors
        /// <summary>
        /// Constructor without parameters for database use only
        /// </summary>
        public Vehicle()
        {
        }
        public Vehicle(string vin)
        {
            Vin = vin;
        }
        public Vehicle(string vin, string vehiclePlate) : this(vin)
        {
            VehiclePlate = vehiclePlate;
        }
        public Vehicle(string vin, string vehiclePlate, string vehicleDescription) : this(vin,vehiclePlate)
        {
            VehicleDescription = vehicleDescription;
        }
        public Vehicle(string vin, string vehiclePlate, string vehicleDescription, Driver driver) : this(vin, vehiclePlate, vehicleDescription)
        {
            Driver = driver;
        }
        #endregion
        #region equals
        public bool Equals(Vehicle other)
        {
            if (other == null) return false;
            if (object.ReferenceEquals(this, other)) return true;
            return (this.Vin == other.Vin && this.VehiclePlate == other.VehiclePlate&&this.VehicleDescription==other.VehicleDescription&&this.PurchaseDate==other.PurchaseDate&&this.InitialKilometersValue==other.InitialKilometersValue&&this.IsActive==other.IsActive&&this.Driver==other.Driver);
        }
        public override bool Equals(object obj)
        {
            if (obj is Vehicle) return Equals((Vehicle)obj);
            else return false;
        }
        public static bool Equals(Vehicle v1, Vehicle v2)
        {
            if ((v1 is null) && (v2 is null)) return true;
            if (v1 is null) return false;
            return v1.Equals(v2);
        }
        public override int GetHashCode() => (this.Vin, this.VehiclePlate, this.VehicleDescription, this.PurchaseDate, this.InitialKilometersValue,this.IsActive, this.Driver).GetHashCode();
        #endregion
        #region operators
        public static bool operator ==(Vehicle v1, Vehicle v2) => v1.Equals(v2);
        public static bool operator !=(Vehicle v1, Vehicle v2) => !(v1.Equals(v2));
        #endregion
    }
}
