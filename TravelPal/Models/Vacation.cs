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

        public override string GetInfo()
        {
            return $"Destination {DestinationCity} in {Country} with travellers {Travellers}. Is 'all inclusive' {AllInclusive}";
        }
    }
}
