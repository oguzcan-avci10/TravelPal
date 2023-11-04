using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        public static List<Travel> Travels { get; set; }

        public static void AddTravel(Travel travel, User user)
        {
            user.Travels.Add(travel);

            Travels.Add(travel);
        }

        public static void PopulateTravels()
        {
            Travels = new List<Travel>();

            foreach(var user in UserManager.Users)
            {
                if(user is User)
                {
                    Travels.AddRange(((User)user).Travels);
                }
            }
        }

        public static void RemoveTravel(Travel travel)
        {
            foreach(var user in UserManager.Users)
            {
                if(user is User)
                {
                    foreach(var userTravel in ((User)user).Travels)
                    {
                        if(userTravel == travel)
                        {
                            ((User)user).Travels.Remove(travel);
                            Travels.Remove(travel);

                            return;
                        }
                    }
                }
            }
        }

        public static void RemoveTravel(Travel travel, User user)
        {
            user.Travels.Remove(travel);
            Travels.Remove(travel);
        }
    }
}
