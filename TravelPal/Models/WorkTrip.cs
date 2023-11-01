using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class WorkTrip : Travel
    {
        public required string? MeetingDetails { get; set; }

        public override string GetInfo()
        {
            return $"City: {DestinationCity}, Travellers: {Travellers}, Country: {Country}\n Details: {MeetingDetails}";
        }
    }
}
