using System;
using System.Collections.Generic;
using DriverLibrary;

namespace VehicleLibrary
{
    public class Vehicle
    {
        private string vin;
        private List<string> vehiclePlate;
        private VehicleType vehicleType;
        private DriverLicense requiredDriverLicese;
        private DateTime purchaseDate;
        private uint initialKilometersValue;
        private DateTime registrationDate;
        private DateTime salesDate;
        private uint endKilometersValue;
        public string AdditionalInformation { get; private set; }
    }
}
