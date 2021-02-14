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
    public abstract class NewEventWindowHelper : EventWindowHelper
    {
        public DateTime EventTime { get; set; }
        public string Description { get; set; }
    }
}
