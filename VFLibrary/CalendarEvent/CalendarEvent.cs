using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary.CalendarEvent
{
    [Table("VehicleCalendarEvents")]
    public class CalendarEvent
    {
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        [Indexed]
        public string Vin { get; set; }
        [Ignore]
        public Vehicle Vehicle { get; set; }
        [Indexed]
        public uint DriverId { get; set; }
        [Ignore]
        public Driver Driver { get; set; }

        public DateTime EventTime { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
