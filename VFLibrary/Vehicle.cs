using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary
{
    public class Vehicle
    {
        private string vin;
        private List<string> vehiclePlate;
        private VehicleType vehicleType;
        private DriverLicense requiredDriverLicese;
        private DateTime purchaseDate;
        private int initialKilometersValue;
        private DateTime registrationDate;
        private DateTime salesDate;
        private int endKilometersValue;
    }
}
