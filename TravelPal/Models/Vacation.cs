using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public required bool AllInclusive { get; set; }

        public string GetInfo()
        {
            return $"Destination {DestinationCity} with travellers {Travellers}. Is 'all inclusive' {AllInclusive}";
        }
    }
}
