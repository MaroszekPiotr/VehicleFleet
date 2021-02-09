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
using VFViewModel.Helpers;

namespace VFViewModel.Vehicles
{
    public class VehiclesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public VehiclesRefreshListCommand VehiclesRefreshListCommand { get; set; }
        private ObservableCollection<Vehicle> vehicles;

        public ObservableCollection<Vehicle> Vehicles
        {
            get => vehicles;
            set { 
                vehicles = value;
                OnPropertyChanged("Vehicles");
            }
        }

        //public ObservableCollection<Vehicle> Vehicles { get; set; }
        private Vehicle selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set { selectedVehicle = value; }
        }

        public VehiclesVM()
        {
            Vehicles = new ObservableCollection<Vehicle>();
            VehiclesRefreshListCommand = new VehiclesRefreshListCommand(this);
            OnPropertyChanged("SelectedVehicle");
            OnPropertyChanged("Vehicles");
            GetVehicleList();
        }


        public void GetVehicleList()
        {
            var vehicles = DatabaseHelper.Read<Vehicle>();

            if (vehicles != null)
            {
                Vehicles.Clear();
                foreach (var vehicle in vehicles)
                {
                    Vehicles.Add(vehicle);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
