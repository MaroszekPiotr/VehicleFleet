using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands;
using VFViewModel.Commands.VehicleCommands;

namespace VFViewModel.Vehicles
{
    public class VehiclesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Vehicle> Vehicles { get; set; }
        private Vehicle selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set { selectedVehicle = value; }
        }

        public VehiclesVM()
        {
            Vehicles = new ObservableCollection<Vehicle>();
            
            GetVehicleList();
        }

        public void CreateNewVehicle()
        {

        }

        public void GetVehicleList() { }
    }
}
