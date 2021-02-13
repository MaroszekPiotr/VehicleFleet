using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands.DriverCommands;
using VFViewModel.Helpers;

namespace VFViewModel.Drivers
{
    public class NewDriverVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Pesel { get; set; }
        public string AdditionalId { get; set; }
        public NewDriverCommand NewDriverCommand { get; set; }
        //public DriversVM DriversVM { get; set; }

        public NewDriverVM()
        {
            NewDriverCommand = new NewDriverCommand(this);
        }

        public void CreateNewDriver()
        {
            Driver driver = new Driver() {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Pesel = this.Pesel,
                AdditionalId = this.AdditionalId,
                Nationality = this.Nationality,
                IsActive = true,
            };
            DatabaseHelper.Insert<Driver>(driver);

        }
    }
}
