using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Drivers;

namespace VFViewModel.Commands.DriverCommands
{
    public class NewDriverCommand : ICommand
    {
        private NewDriverVM Vm { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add {}
            remove { }

        }
        public NewDriverCommand(NewDriverVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.CreateNewDriver();
        }
    }
}
