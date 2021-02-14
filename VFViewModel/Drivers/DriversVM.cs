using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands.DriverCommands;
using VFViewModel.Helpers;

namespace VFViewModel.Drivers
{
    public class DriversVM : WindowHelper
    {
        #region command
        public DriversRefreshListCommand DriversRefreshListCommand { get; set; }
        public ShowArchivedDriversCommand ShowArchivedDriversCommand { get; set;}
        public SetDriverAsArchiveCommand SetDriverAsArchiveCommand { get; set; }
        public SetDriverAsActiveCommand SetDriverAsActiveCommand { get; set; }
        public UpdateDriverCommand UpdateDriverCommand { get; set; }
        #endregion
        public ObservableCollection<Driver> Drivers { get; set; }
        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get => selectedDriver;
            set
            {
                selectedDriver = value;
                OnPropertyChanged("SelectedDriver");
            }
        }
        public DriversVM()
        {
            Drivers = new ObservableCollection<Driver>();
            DriversRefreshListCommand = new DriversRefreshListCommand(this);
            ShowArchivedDriversCommand = new ShowArchivedDriversCommand(this);
            SetDriverAsArchiveCommand = new SetDriverAsArchiveCommand(this);
            UpdateDriverCommand = new UpdateDriverCommand(this);
            GetDriversList(true);
        }

        public void GetDriversList(bool isActiveValue)
        {
            var drivers = DatabaseHelper.Read<Driver>().Where(driver=>driver.IsActive==isActiveValue);
            Drivers.Clear();
            foreach (var driver in drivers)
            {
                Drivers.Add(driver);
            }
        }

        public void SetDriverStatus(bool value)
        {
            selectedDriver.IsActive = value;
            UpdateSelectedDriver();
        }

        public void UpdateSelectedDriver()
        {
            DatabaseHelper.Update<Driver>(selectedDriver);
            GetDriversList(true);
        }
    }
}
