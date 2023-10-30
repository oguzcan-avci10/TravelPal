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

namespace TravelPal.Views
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();
            for (int i = 1; i <= 10; i++)
            {
                cmbTravellers.Items.Add(i);
            }
            

            foreach (var country in Enum.GetValues(typeof(Countries)))
            {
                cmbDestination.Items.Add(country);  
            }

            cmbTrip.Items.Add("Vacation");
            cmbTrip.Items.Add("Work Trip");
        }

        private void cmbTrip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTrip.SelectedItem.ToString() == "Vacation")
            {
                lblAllinclusive.Visibility = Visibility.Visible;
                checkAllinclusive.Visibility = Visibility.Visible;
                lblMeeting.Visibility = Visibility.Hidden;
                txtMeeting.Visibility = Visibility.Hidden;

            }
            else
            {
                lblMeeting.Visibility = Visibility.Visible;
                txtMeeting.Visibility = Visibility.Visible;

                lblAllinclusive.Visibility = Visibility.Hidden;
                checkAllinclusive.Visibility = Visibility.Hidden;
            }
           
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTravellers.SelectedItem == null || cmbDestination.SelectedItem == null || string.IsNullOrEmpty(txtCity.Text) || cmbTrip.SelectedItem == null)
            {
                
                
                    MessageBox.Show("Input fields cannot be empty!");
                
            }
        }

       
    }
}
