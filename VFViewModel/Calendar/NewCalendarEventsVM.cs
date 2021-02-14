using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFLibrary.CalendarEvent;
using VFViewModel.Commands.CalendarCommands;
using VFViewModel.Drivers;
using VFViewModel.Helpers;
using VFViewModel.Vehicles;

namespace VFViewModel.Calendar
{
    public class NewCalendarEventsVM : NewEventWindowHelper
    {
        #region command
        public NewCalendarEventCommand NewCalendarEventCommand { get; set; }
        #endregion

        public NewCalendarEventsVM()
        {
            NewCalendarEventCommand = new NewCalendarEventCommand(this);
            VehiclesVM = new VehiclesVM();
            DriversVM = new DriversVM();
            EventTime = DateTime.Today;
        }
        public void CreateCalendarEvent()
        {
            CalendarEvent calendarEvent = new CalendarEvent()
            {
                EventTime = this.EventTime,
                Description = this.Description,
                Vin = this.VehiclesVM.SelectedVehicle.Vin,
                DriverId = this.VehiclesVM.SelectedVehicle.DriverID,
            };
            DatabaseHelper.Insert<CalendarEvent>(calendarEvent);
        }
    }
}
