using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Calendar;

namespace VFViewModel.Commands.CalendarCommands
{
    public class DeleteSchaduleEventCommand : ICommand
    {
        private SchaduleEventsVM SchaduleEventsVM { get; set; } 
        public event EventHandler CanExecuteChanged;

        public DeleteSchaduleEventCommand(SchaduleEventsVM schaduleEventsVM)
        {
            SchaduleEventsVM = schaduleEventsVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SchaduleEventsVM.DeleteSelectedEvent();
        }
    }
}
