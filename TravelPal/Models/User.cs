using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Travel> Travels { get; set; } = new List<Travel>(); 
       
        public User(string username, string password)
        {
            Username = username;
            Password = password;
           
        }
    }

    
}
