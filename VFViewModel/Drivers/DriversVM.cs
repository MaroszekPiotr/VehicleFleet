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
    public class DriversVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DriversRefreshListCommand DriversRefreshListCommand { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }
        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get => selectedDriver;
            set { selectedDriver = value; }
        }
        public DriversVM()
        {
            Drivers = new ObservableCollection<Driver>();
            DriversRefreshListCommand = new DriversRefreshListCommand(this);
            OnPropertyChanged("Drivers");
            OnPropertyChanged("SelectedDriver");
            GetDriversList();
        }

        public void GetDriversList()
        {
            var drivers = DatabaseHelper.Read<Driver>();
            Drivers.Clear();
            foreach(var driver in drivers)
            {
                Drivers.Add(driver);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
