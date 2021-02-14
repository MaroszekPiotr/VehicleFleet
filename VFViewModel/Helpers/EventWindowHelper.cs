using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Drivers;
using VFViewModel.Vehicles;

namespace VFViewModel.Helpers
{
    public abstract class EventWindowHelper : WindowHelper
    {
        public DriversVM DriversVM { get; set; }
        public VehiclesVM VehiclesVM { get; set; }
        public DateTime EventTime { get; set; }
        public string Description { get; set; }
    }
}
