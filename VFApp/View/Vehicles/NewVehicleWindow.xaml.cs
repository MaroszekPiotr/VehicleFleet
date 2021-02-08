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

namespace VFApp.View.Vehicles
{
    /// <summary>
    /// Interaction logic for NewDriverWindow.xaml
    /// </summary>
    public partial class NewVehicleWindow : Window
    {
        public NewVehicleWindow()
        {
            InitializeComponent();
        }

        private void CloseWindowClick(object sender, RoutedEventArgs e)
        {
            //save action
            this.Close();
        }
    }
}
