using System;

namespace TravelPal.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public int Travellers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelDays { get; set; }
    }
}