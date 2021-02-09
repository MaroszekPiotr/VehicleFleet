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

namespace VFApp.View.Drivers
{
    /// <summary>
    /// Interaction logic for DriversWindow.xaml
    /// </summary>
    public partial class DriversWindow : Window
    {
        public DriversWindow()
        {
            InitializeComponent();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
