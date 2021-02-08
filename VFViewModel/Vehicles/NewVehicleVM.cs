using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands.VehicleCommands;
using VFViewModel.Helpers;

namespace VFViewModel.Vehicles
{
    public class NewVehicleVM
    {
        public string Vin { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleDescription { get; set; }
        public DateTime purchaseDate { get;  set; }
        public int InitialKilometersValue { get; set; }
        public int DriverID { get; set; }
        public NewVehicleCommand NewVehicleCommand { get; set; }
        public NewVehicleVM()
        {
            NewVehicleCommand = new NewVehicleCommand(this);
        }

        public void CreateNewVehicle()
        {
            Vehicle vehicle = new Vehicle(Vin);
            DatabaseHelper.Insert<Vehicle>(vehicle);
        }
    }
}
