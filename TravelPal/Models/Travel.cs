using System;

namespace TravelPal.Models
{
    public class Travel
    {
        public required string? DestinationCity { get; set; }
        public required int Travellers { get; set; }
        public required Countries Country { get; set; }

        

        // TODO: Städer som användaren ska kunna välja emellan
        // Vacation eller WorkTrip
        // TravelDetailsWindow
        // Funktionalitet
        // Använd SignedInUser 

    }
}