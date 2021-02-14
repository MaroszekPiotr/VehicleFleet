using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary.VehicleEvent
{
    [Table("VehicleHistory")]
    public class VehicleHistory
    {
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        [Indexed]
        public string Vin { get; set; }
        public string Description { get; set; }
        public DateTime EventTime { get; set; }
        public int VehicleKilometersValue { get; set; }
        [Indexed]
        public uint DriverId { get; set; }
    }
}
