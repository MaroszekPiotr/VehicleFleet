using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [PrimaryKey]
        public string Vin { get; private set; }
        public string VehiclePlate { get; set; }
        public string VehicleDescription { get; set; }
        public DateTime purchaseDate{ get; private set; }
        public int InitialKilometersValue { get; }
        public DateTime RegistrationDate { get; set; }
        public DateTime SalesDate { get; set; }
        public int EndKilometersValue { get; set; }
        [Indexed]
        public int DriverID { get; set; }

        public Vehicle(string vin)
        {
            Vin = vin;
        }
    }
}
