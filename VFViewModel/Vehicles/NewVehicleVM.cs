using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands.VehicleCommands;
using VFViewModel.Drivers;
using VFViewModel.Helpers;

namespace VFViewModel.Vehicles
{
    public class NewVehicleVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DriversVM DriversVM { get; set; }
        private ObservableCollection<Driver> drivers;
        public ObservableCollection<Driver> Drivers
        {
            get => drivers;
            set
            {
                drivers = value;
                OnPropertyChanged("Drivers");
            }
        }
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
        public string Vin { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleDescription { get; set; }
        public DateTime purchaseDate { get; set; }
        public int InitialKilometersValue { get; set; }
        public uint DriverID { get; set; }
        public NewVehicleCommand NewVehicleCommand { get; set; }
        public NewVehicleVM()
        {
            NewVehicleCommand = new NewVehicleCommand(this);
            DriversVM = new DriversVM();
            Drivers = DriversVM.Drivers;
            purchaseDate = DateTime.Today;
            OnPropertyChanged("Drivers");
            OnPropertyChanged("SelectedDriver");
        }


        public void CreateNewVehicle()
        {
            if (this.Vin!= null)
            {
                Vehicle vehicle = new Vehicle()
                {
                    Vin = this.Vin,
                    VehiclePlate = this.VehiclePlate,
                    VehicleDescription = this.VehicleDescription,
                    PurchaseDate = this.purchaseDate,
                    InitialKilometersValue = this.InitialKilometersValue,
                    DriverID = this.selectedDriver.Id,
                    IsActive = true,

                };
                DatabaseHelper.Insert<Vehicle>(vehicle);
            }
            
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
