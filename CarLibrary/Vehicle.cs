using System;
using System.Collections.Generic;
using DriverLibrary;

namespace CarLibrary
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
