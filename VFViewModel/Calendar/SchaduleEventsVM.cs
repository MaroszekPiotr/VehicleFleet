using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary.CalendarEvent;
using VFViewModel.Commands.CalendarCommands;
using VFViewModel.Helpers;

namespace VFViewModel.Calendar
{
    public class SchaduleEventsVM : ListEventWindowHelper
    {
        #region commands
        public RefreshSchaduleListCommand RefreshSchaduleListCommand { get; set; }
        public SetSchaduleEventAsDoneCommand SetSchaduleEventAsDoneCommand { get; set; }
        public DeleteSchaduleEventCommand DeleteSchaduleEventCommand { get; set; }
        #endregion
        public ObservableCollection<CalendarEvent> SchaduleEvents { get; set; }

        private CalendarEvent selectedEvent;

        public CalendarEvent SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

        public SchaduleEventsVM()
        {
            RefreshSchaduleListCommand = new RefreshSchaduleListCommand(this);
            SetSchaduleEventAsDoneCommand = new SetSchaduleEventAsDoneCommand(this);
            DeleteSchaduleEventCommand = new DeleteSchaduleEventCommand(this);
            SchaduleEvents = new ObservableCollection<CalendarEvent>();
            GetSchaduleEvents(false);
        }

        public void GetSchaduleEvents(bool isDone)
        {
            var schaduleEvents = DatabaseHelper.Read<CalendarEvent>().Where(schaduleEvent => schaduleEvent.IsDone == isDone);
            SchaduleEvents.Clear();
            foreach (var schaduleEvent in schaduleEvents)
            {
                schaduleEvent.Driver= ReadDriver(schaduleEvent.DriverId);
                schaduleEvent.Vehicle = ReadVehicle(schaduleEvent.Vin);
                SchaduleEvents.Add(schaduleEvent);
            }
        }

        public void SetSelectedEventAsDone()
        {
            SelectedEvent.IsDone = true;
            DatabaseHelper.Update<CalendarEvent>(SelectedEvent);
            GetSchaduleEvents(false);
        }
        public void DeleteSelectedEvent()
        {
            DatabaseHelper.Delete<CalendarEvent>(SelectedEvent);
            GetSchaduleEvents(false);
        }

    }
}
