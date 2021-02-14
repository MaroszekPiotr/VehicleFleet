using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VFApp.View.Calendar;
using VFApp.View.Drivers;
using VFApp.View.Event;
using VFApp.View.Vehicles;

namespace VFApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenVehicleWindowClick(object sender, RoutedEventArgs e)
        {
            VehicleWindow vehicleWindow = new VehicleWindow();
            vehicleWindow.ShowDialog();
        }

        private void OpenDriverWindowClick(object sender, RoutedEventArgs e)
        {
            DriversWindow driversWindow = new DriversWindow();
            driversWindow.ShowDialog();
        }

        private void AddCalendarEventClick(object sender, RoutedEventArgs e)
        {
            NewCalendarEventWindow newCalendarEventWindow = new NewCalendarEventWindow();
            newCalendarEventWindow.ShowDialog();
        }

        private void AddDriverClick(object sender, RoutedEventArgs e)
        {
            NewDriverWindow newDriverWindow = new NewDriverWindow();
            newDriverWindow.ShowDialog();
        }

        private void AddVehicleClick(object sender, RoutedEventArgs e)
        {
            NewVehicleWindow newVehicleWindow = new NewVehicleWindow();
            newVehicleWindow.ShowDialog();
        }

        private void AddNewVehicleEventClick(object sender, RoutedEventArgs e)
        {
            NewEventWindow vehicleWindow = new NewEventWindow();
            vehicleWindow.ShowDialog();
        }

        private void VehicleEventsWindow(object sender, RoutedEventArgs e)
        {
            VehicleEventsWindow vehicleEventsWindow = new VehicleEventsWindow();
            vehicleEventsWindow.ShowDialog();
        }
    }
}
