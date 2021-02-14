using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFViewModel.Calendar;

namespace VFViewModel.Commands.CalendarCommands
{
    public class NewCalendarEventCommand : ICommand
    {
        private NewCalendarEventsVM CalendarEventsVM { get; set; }
        public event EventHandler CanExecuteChanged;
        public NewCalendarEventCommand(NewCalendarEventsVM calendarEventsVM)
        {
            CalendarEventsVM = calendarEventsVM;              
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CalendarEventsVM.CreateCalendarEvent();
        }
    }
}
