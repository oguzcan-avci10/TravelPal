using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class UserManager
    {
        public static List<IUser> Users { get; set; } = new()
        {
            new User("user", "password")
            {
                Travels = new List<Travel>()
                {
                    new Vacation()
                    {
                        DestinationCity = "Stockholm",
                        Travellers = 2,
                        Country = Countries.Sweden,
                        AllInclusive = true
                    },
                    new WorkTrip()
                    {
                        DestinationCity = "Milano",
                        Travellers = 3,
                        Country = Countries.Italy,
                        MeetingDetails = "Meeting with a software developer company"
                    }
                }
            },
            new Admin("admin", "password")
        };


       public static IUser? SignedInUser { get; set; }


        public static bool AddUser(string username, string password)
        {
            if(ValidateUsername(username))
            {
                User user = new User(username, password);  
                Users.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }
        

        private static bool ValidateUsername (string username)
        {
            bool IsValidUsername = false;
            if (!string.IsNullOrEmpty(username))
            {
                IsValidUsername = true;
            }

            foreach (var user in Users)
            {
                if (user.Username == username)
                {
                    IsValidUsername = false;
                }

            }
            return IsValidUsername; 
        }

        public static bool SignInUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    SignedInUser = user;
                    return true;
                }
            }
            return false;
        }


    }
}
