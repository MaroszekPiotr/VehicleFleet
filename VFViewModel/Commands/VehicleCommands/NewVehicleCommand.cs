using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Vehicles;

namespace VFViewModel.Commands.VehicleCommands
{
    public class NewVehicleCommand : ICommand
    {
        private NewVehicleVM Vm { get; set; }

        public event EventHandler CanExecuteChanged;

        public NewVehicleCommand(NewVehicleVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.CreateNewVehicle();
        }
    }
}
