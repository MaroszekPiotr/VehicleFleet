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
        public string Vin { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleDescription { get; set; }
        public DateTime PurchaseDate{ get; set; }
        public int InitialKilometersValue { get; set; }
        public bool IsActive { get; set; } = true;
        [Indexed]
        public uint DriverID { get; set; }

        public Vehicle()
        {
        }
    }
}
