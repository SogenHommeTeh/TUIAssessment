using System;

namespace TUI.Data.Flights.Options
{
    public class FlightPostOptions
    {
        public Guid DepartureAirportId { get; set; }

        public DateTime DepartureTime { get; set; }

        public Guid ArrivalAirportId { get; set; }

        public DateTime ArrivalTime { get; set; }

        public Guid AircraftId { get; set; }
    }
}
