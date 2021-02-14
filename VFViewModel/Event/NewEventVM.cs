using System;
using System.Collections.Generic;
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
    public class NewEventVM : EventWindowHelper
    {
        #region commands
        public NewEventCommand NewEventCommand { get; set; }
        #endregion
        public NewEventVM()
        {
            NewEventCommand = new NewEventCommand(this);
            VehiclesVM = new VehiclesVM();
            DriversVM = new DriversVM();
            EventTime = DateTime.Today;
        }
        public void CreateEvent()
        {
            VehicleHistory vehicleHistoryEvent = new VehicleHistory()
            {
                EventTime = this.EventTime,
                Description = this.Description,
                Vin = this.VehiclesVM.SelectedVehicle.Vin,
                DriverId = this.VehiclesVM.SelectedVehicle.DriverID,
            };
            DatabaseHelper.Insert<VehicleHistory>(vehicleHistoryEvent);
        }
    }
}
