using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Event;

namespace VFViewModel.Commands.EventCommand
{
    public class VehicleEventFilterCommand : ICommand
    {
        private VehiclesEventsVM VehiclesEventsVM { get; set; }
        public event EventHandler CanExecuteChanged;
        public VehicleEventFilterCommand(VehiclesEventsVM vehiclesEventsVM)
        {
            VehiclesEventsVM = vehiclesEventsVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VehiclesEventsVM.FilterVehicleEventsList();
        }
    }
}
