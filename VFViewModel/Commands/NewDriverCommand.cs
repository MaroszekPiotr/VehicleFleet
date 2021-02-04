using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VFViewModel.Commands
{
    public class NewDriverCommand : ICommand
    {
        public VehicleFleetVM Vm { get; set; }

        public event EventHandler CanExecuteChanged;
        public NewDriverCommand(VehicleFleetVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.CreateDriver();
        }
    }
}
