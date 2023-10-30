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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.Views;

namespace TravelPal
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

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Password;

            bool isLoggedIn = UserManager.SignInUser(userName, password);

            if(!isLoggedIn)
            {
                MessageBox.Show("Wrong username or password!");
                CleanUI();
            }
            else
            {
                TravelWindow travelWindow = new TravelWindow(userName);
                travelWindow.Show();
                Close();
            }


        }
        private void CleanUI()
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }

      
      
    }
    
}
