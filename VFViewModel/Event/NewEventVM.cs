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
    public class NewEventVM : NewEventWindowHelper
    {
        #region commands
        public NewEventCommand NewEventCommand { get; set; }
        #endregion
        public uint VehicleKilometersValue { get; set; } = 0;
        public NewEventVM()
        {
            NewEventCommand = new NewEventCommand(this);
            VehiclesVM = new VehiclesVM();
            DriversVM = new DriversVM();
            EventTime = DateTime.Today;
        }
        public void CreateEvent()
        {
            if (VehiclesVM.SelectedVehicle!=null)
            {
                VehicleHistory vehicleHistoryEvent = new VehicleHistory()
                {
                    EventTime = this.EventTime,
                    Description = this.Description,
                    Vin = this.VehiclesVM.SelectedVehicle.Vin,
                    DriverId = this.VehiclesVM.SelectedVehicle.DriverID,
                    VehicleKilometersValue = this.VehicleKilometersValue
                };
                DatabaseHelper.Insert<VehicleHistory>(vehicleHistoryEvent);
            }
            
        }
    }
}
