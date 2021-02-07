/*using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands;
using VFViewModel.Helpers;

namespace VFViewModel
{
    public class VehicleFleetVM
    {
        public ObservableCollection<Driver> Drivers { get; set; }
        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get => selectedDriver;
            set { selectedDriver = value; }
        }


        public ObservableCollection<Vehicle> Vehicles { get; set; }
        private Vehicle selectedVehicle;

        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set { selectedVehicle = value; }
        }
        public NewDriverCommand NewDriverCommand { get; set; }
        public oldNewVehicleCommand NewVehicleCommand { get; set; }
        public VehicleFleetVM()
        {
            NewDriverCommand = new NewDriverCommand(this);
            NewVehicleCommand = new oldNewVehicleCommand(this);
        }

        public void CreateDriver()
        {
            Driver newDriver = new Driver("new", "new", "", "NU");
            DatabaseHelper.Insert(newDriver);
        }

        *//*public void CreateVehicle()
        {
            Vehicle newVehicle = new Vehicle();
            DatabaseHelper.Insert(newVehicle);
        }*//*
    }
}
*/