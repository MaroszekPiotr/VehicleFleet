using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;

namespace VFViewModel.Helpers
{
    public abstract class ListEventWindowHelper : EventWindowHelper
    {
        //public Driver Driver { get; set; }
        //public Vehicle Vehicle { get; set; }

        public static Driver ReadDriver(uint driverID)
        {
            Driver driver = null;
            var query = DatabaseHelper.Read<Driver>().Where(driver => driver.Id == driverID).ToList()[0];
            if (query != null) driver = query;
            return driver;
        }
        public static Vehicle ReadVehicle(string vin)
        {
            Vehicle vehicle = null;
            var query = DatabaseHelper.Read<Vehicle>().Where(vehicle => vehicle.Vin == vin).ToList()[0];
            if (query != null) vehicle = query;
            return vehicle;
        }
    }
}
