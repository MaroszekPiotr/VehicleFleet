using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFLibrary
{
    public class DriverLicense
    {
        public int Id { get; set; }
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
