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
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        

        public TravelDetailsWindow(Travel selectedTrip)
        {
            InitializeComponent();

            txtDetails.Text = selectedTrip.GetInfo();
            
                
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelWindow travelWindow = new TravelWindow();
            travelWindow.Show();
            Close();

        }
    }
}
