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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

       
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string newUserName = txtUsername.Text;
            string newUserPassword = txtPassword.Text;

            if (IsValidName(newUserName))
            {
                User newUser = new User(newUserName, newUserPassword);
                UserManager.Users.Add(newUser);
                MessageBox.Show($"Registered new user with name {newUserName}", "Succes");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }

        }

        // Validate username - check for empty strings or if username already exists.
        private bool IsValidName(string name)
        {

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name or password fields cannot be empty!", "Warning");
                return false;
            }

            else
            {
                for (int i = 0; i < UserManager.Users.Count; i++)
                {
                    string unAvailableName = UserManager.Users[i].Username;
                    if (name == unAvailableName)
                    {
                        MessageBox.Show("Username is taken!", "Warning");
                        return false;
                    }
                }
                return true; 
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
