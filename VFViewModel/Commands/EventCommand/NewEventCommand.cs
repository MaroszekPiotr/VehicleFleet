using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Event;

namespace VFViewModel.Commands.EventCommand
{
    public class NewEventCommand : ICommand
    {
        public NewEventVM NewEventVM { get; set; }
        public event EventHandler CanExecuteChanged;

        public NewEventCommand(NewEventVM newEventVM)
        {
            NewEventVM = newEventVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NewEventVM.CreateEvent();
        }
    }
}
