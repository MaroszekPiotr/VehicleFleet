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
        [Indexed]
        public uint DriverId { get; set; }

        public DateTime EventTime { get; set; }
        public string Decription { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
