using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands.DriverCommands;
namespace VFViewModel.Drivers
{
    public class DriversVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Driver> Drivers { get; set; }
        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get => selectedDriver;
            set { selectedDriver = value; }
        }
        public DriversVM()
        {
            Drivers = new ObservableCollection<Driver>();
            GetDriversList();
        }

        public void CreateNewDriver()
        {
            
        }

        public void GetDriversList()
        {

        }

    }
}
