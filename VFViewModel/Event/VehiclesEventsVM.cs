using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary.VehicleEvent;
using VFViewModel.Helpers;
using VFViewModel.Vehicles;

namespace VFViewModel.Event
{
    public class VehiclesEventsVM : ListEventWindowHelper
    {
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
            VehiclesEvents = new ObservableCollection<VehicleHistory>();
            GetVehicleEvents();
        }
        public void GetVehicleEvents()
        {
            var vehicleEvents = DatabaseHelper.Read<VehicleHistory>().OrderBy(vehicleEvent=>vehicleEvent.EventTime);//.Where(vehicle=>vehicle.Vin==selectedVehicleHistory.Vin).ToList();
            VehiclesEvents.Clear();
            foreach(var vehicleEvent in vehicleEvents)
            {
                vehicleEvent.Vehicle = ReadVehicle(vehicleEvent.Vin);
                VehiclesEvents.Add(vehicleEvent);
            }
        }
    }
}
