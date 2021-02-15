using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary.VehicleEvent;
using VFViewModel.Commands.EventCommand;
using VFViewModel.Drivers;
using VFViewModel.Helpers;
using VFViewModel.Vehicles;

namespace VFViewModel.Event
{
    public class VehiclesEventsVM : ListEventWindowHelper
    {
        #region commands
        public VehicleEventFilterCommand VehicleEventFilterCommand { get; set; }
        #endregion
        public ObservableCollection<VehicleHistory> VehiclesEvents { get; set; }
        private VehicleHistory selectedVehicleHistory;

        public VehicleHistory SelectedVehicleHistory
        {
            get => selectedVehicleHistory;
            set
            {
                selectedVehicleHistory = value;
                OnPropertyChanged("SelectedVehicleHistory");
            }
        }

        public VehiclesEventsVM()
        {
            VehiclesVM = new VehiclesVM();
            DriversVM = new DriversVM();
            VehiclesEvents = new ObservableCollection<VehicleHistory>();
            VehicleEventFilterCommand = new VehicleEventFilterCommand(this);
            GetVehicleEvents();
        }
        public void GetVehicleEvents(string filterVinNumber = "")
        {
            IEnumerable<VehicleHistory> vehicleEvents;
            if (String.IsNullOrEmpty(filterVinNumber))
            {
                vehicleEvents = DatabaseHelper.Read<VehicleHistory>().OrderBy(vehicleEvent => vehicleEvent.EventTime);
            }
            else
            {

                vehicleEvents = DatabaseHelper.Read<VehicleHistory>().Where(vehicle => vehicle.Vin == VehiclesVM.SelectedVehicle.Vin).OrderBy(vehicleEvent => vehicleEvent.EventTime);
            }
            VehiclesEvents.Clear();
            foreach (var vehicleEvent in vehicleEvents)
            {
                vehicleEvent.Vehicle = ReadVehicle(vehicleEvent.Vin);
                if (vehicleEvent.DriverId != 0) vehicleEvent.Driver = ReadDriver(vehicleEvent.DriverId);
                VehiclesEvents.Add(vehicleEvent);
            }
        }
        public void FilterVehicleEventsList()
        {
            if (VehiclesVM.SelectedVehicle != null)
            {
                GetVehicleEvents(VehiclesVM.SelectedVehicle.Vin);
            }
        }
    }
}
