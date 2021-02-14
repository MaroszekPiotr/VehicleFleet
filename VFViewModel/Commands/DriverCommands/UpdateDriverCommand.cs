using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Drivers;

namespace VFViewModel.Commands.DriverCommands
{
    public class UpdateDriverCommand : ICommand
    {
        private DriversVM DriversVM { get; set; }
        public event EventHandler CanExecuteChanged;
        public UpdateDriverCommand(DriversVM driversVM)
        {
            DriversVM = driversVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DriversVM.UpdateSelectedDriver();
        }
    }
}
