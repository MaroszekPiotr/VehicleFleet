using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands;
using VFViewModel.Commands.VehicleCommands;
using VFViewModel.Drivers;
using VFViewModel.Helpers;

namespace VFViewModel.Vehicles
{
    public class VehiclesVM : WindowHelper
    {
        #region commands
        public VehiclesRefreshListCommand VehiclesRefreshListCommand { get; set; }
        public ShowArchivedVehiclesCommand ShowArchivedVehiclesCommand { get; set; }
        public SetVehicleAsActiveCommand SetVehicleAsActiveCommand { get; set; }
        public SetVehicleAsArchiveCommand SetVehicleAsArchiveCommand { get; set; }
        public UpdateVehicleCommand UpdateVehicleCommand { get; set; }
        #endregion
        public DriversVM DriversVM { get; set; }
        private Driver assignedDriver;

        public Driver AssignedDriver
        {
            get => assignedDriver;
            set { 
                assignedDriver = value;
                OnPropertyChanged("AssignedDriver");
            }
        }



        private ObservableCollection<Vehicle> vehicles;

        public ObservableCollection<Vehicle> Vehicles
        {
            get => vehicles;
            set { 
                vehicles = value;
                OnPropertyChanged("Vehicles");
            }
        }
        private Vehicle selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set 
            { 
                selectedVehicle = value;
                AssignedDriver = GetAssignedDriver();
                OnPropertyChanged("SelectedVehicle");
            }
        }

        public VehiclesVM()
        {
            DriversVM = new DriversVM();
            Vehicles = new ObservableCollection<Vehicle>();
            VehiclesRefreshListCommand = new VehiclesRefreshListCommand(this);
            ShowArchivedVehiclesCommand = new ShowArchivedVehiclesCommand(this);
            SetVehicleAsActiveCommand = new SetVehicleAsActiveCommand(this);
            SetVehicleAsArchiveCommand = new SetVehicleAsArchiveCommand(this);
            UpdateVehicleCommand = new UpdateVehicleCommand(this);
            GetVehicleList(true);
        }


        public void GetVehicleList(bool isActiveValue)
        {
            var vehicles = DatabaseHelper.Read<Vehicle>().Where(vehicle=>vehicle.IsActive==isActiveValue).OrderBy(vehice=>vehice.VehicleDescription).ThenBy(vehicle=>vehicle.VehiclePlate).ThenBy(vehicle=>vehicle.Vin);

            if (vehicles != null)
            {
                Vehicles.Clear();
                foreach (var vehicle in vehicles)
                {
                    Vehicles.Add(vehicle);
                }
            }
        }

        public void SetVehicleStatus(bool value)
        {
            selectedVehicle.IsActive = value;
            UpdateSelectedVehicle();
        }

        public void AssaignSelectedDriverToVehicle()
        {
            selectedVehicle.DriverID = DriversVM.SelectedDriver.Id;
            UpdateSelectedVehicle();
        }

        public void UpdateSelectedVehicle()
        {
            DatabaseHelper.Update<Vehicle>(SelectedVehicle);
            GetVehicleList(true);
        }

        private Driver GetAssignedDriver()
        {
            Driver driver = null;
            if (selectedVehicle.DriverID != 0)
            {
                uint driverId = selectedVehicle.DriverID;
                var query = DriversVM.Drivers.Where(driver => driver.Id == driverId).ToList()[0];
                if (query != null)
                {
                    driver = query;
                }
            }
            return driver;
        }
    }
}
