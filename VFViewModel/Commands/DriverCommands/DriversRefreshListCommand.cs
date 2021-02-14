using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Drivers;

namespace VFViewModel.Commands.DriverCommands
{
    public class DriversRefreshListCommand : ICommand
    {
        private DriversVM DriversVM;
        public event EventHandler CanExecuteChanged;

        public DriversRefreshListCommand(DriversVM driversVM)
        {
            DriversVM = driversVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           DriversVM.GetDriversList(true);
        }
    }
}
