using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Vehicles;

namespace VFViewModel.Commands.VehicleCommands
{
    public class SetVehicleAsArchiveCommand : ICommand
    {
        public VehiclesVM VehiclesVM { get; set; }
        public event EventHandler CanExecuteChanged;

        public SetVehicleAsArchiveCommand(VehiclesVM vehiclesVM)
        {
            VehiclesVM = vehiclesVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VehiclesVM.SetVehicleStatus(false);
        }
    }
}
