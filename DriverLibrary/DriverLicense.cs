using System;
using System.Collections.Generic;
using System.Text;

namespace DriverLibrary
{
    public class DriverLicense
    {
        private LicenseCategory licenseCategory;
        public DateTime licenseValidFrom { get; private set; }
        public DateTime licenseValidTo { get; private set; }
        public DriverLicense(LicenseCategory licenseCategory, DateTime licenseValidFrom, DateTime licenseValidTo)
        {
            this.licenseCategory = licenseCategory;
            this.licenseValidFrom = licenseValidFrom;
            this.licenseValidTo = licenseValidTo;
        }
    }
}
