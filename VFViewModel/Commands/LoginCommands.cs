using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VFViewModel.Commands
{
    public class LoginCommands : ICommand
    {
        public LoginVM Vm { get; set; }
        public event EventHandler CanExecuteChanged;

        public LoginCommands(LoginVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //todo
        }
    }
}
