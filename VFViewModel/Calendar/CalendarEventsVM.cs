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
using VFViewModel.Helpers;
using VFViewModel.Vehicles;

namespace VFViewModel.Calendar
{
    public class CalendarEventsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public NewCalendarEventCommand NewCalendarEventCommand { get; set; }
        public VehiclesVM VehiclesVM { get; set; }
        private ObservableCollection<Vehicle> vehicles;
        public ObservableCollection<Vehicle> Vehicles { get => vehicles; set { vehicles = value; } }
        private Vehicle selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set
            {
                selectedVehicle = value;
                OnPropertyChanged("SelectedVehicle");
            }
        }
        public DateTime EventTime { get; set; }
        public string Decription { get; set; }

        public CalendarEventsVM()
        {
            NewCalendarEventCommand = new NewCalendarEventCommand(this);
            VehiclesVM = new VehiclesVM();
            Vehicles = VehiclesVM.Vehicles;
        }
        public void CreateCalendarEvent()
        {
            CalendarEvent calendarEvent = new CalendarEvent()
            {
                EventTime = this.EventTime,
                Decription = this.Decription,
                Vin = this.selectedVehicle.Vin,
                DriverId = this.selectedVehicle.DriverID,
            };
            DatabaseHelper.Insert<CalendarEvent>(calendarEvent);

        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
