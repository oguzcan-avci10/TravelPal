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
    /// Interaction logic for TravelWindow.xaml
    /// </summary>
    public partial class TravelWindow : Window
    {
        public TravelWindow()
        {
           
            InitializeComponent();

            if (UserManager.SignedInUser is Admin)
            {
                btnInfo.Visibility = Visibility.Hidden;
                btnAddTravel.Visibility = Visibility.Hidden;
            }

            lblUser.Content= UserManager.SignedInUser.Username;

            if(UserManager.SignedInUser is User)
            {
                // En vanlig user... Ser sina resor
                foreach (Travel trip in ((User)UserManager.SignedInUser).Travels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Content = trip.DestinationCity + " " + "(" + trip.GetType().Name.ToLower() + ")";
                    item.Tag = trip;

                    lstTravel.Items.Add(item);
                }
            }
            else if (UserManager.SignedInUser is Admin)
            {
                // En admin... Ser allas resor

                List<Travel> allTravels = TravelManager.Travels;

                foreach (Travel trip in allTravels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Content = trip.DestinationCity + " " + "(" + trip.GetType().Name.ToLower() + ")";
                    item.Tag = trip;

                    lstTravel.Items.Add(item);
                }
            }   
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e) 
        {
            if(lstTravel.SelectedItem == null)
            {
                MessageBox.Show("Please select a trip", "Warning");
            }
            else
            {
                ListViewItem trip = (ListViewItem)lstTravel.SelectedItem;
                Travel selectedTravel = (Travel)trip.Tag;
                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedTravel);
                travelDetailsWindow.Show();
                Close();
            }
           
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstTravel.SelectedItem;

            if(selectedItem != null)
            {
                Travel selectedTravel = (Travel)selectedItem.Tag;

                if(UserManager.SignedInUser is User)
                {
                    TravelManager.RemoveTravel(selectedTravel, (User)UserManager.SignedInUser);
                }
                else if(UserManager.SignedInUser is Admin)
                {
                    TravelManager.RemoveTravel(selectedTravel);
                    
                }

                lstTravel.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a trip", "Warning");
            }
            
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click 'Add Travel' to add a new trip. Click 'Details' for more info about selected trip.");
        }
    }
}
