using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Calendar;

namespace VFViewModel.Commands.CalendarCommands
{
    public class SetSchaduleEventAsDoneCommand : ICommand
    {
        private SchaduleEventsVM SchaduleEventsVM { get; set; }
        public event EventHandler CanExecuteChanged;

        public SetSchaduleEventAsDoneCommand(SchaduleEventsVM schaduleEventsVM)
        {
            SchaduleEventsVM = schaduleEventsVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SchaduleEventsVM.SetSelectedEventAsDone();
        }
    }
}
