using System;
using System.Collections.Generic;
using System.Text;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Airports.Models;
using TUI.Data.Flights.Models;

namespace TUI.Data.Flights.DTOs
{
    public class FlightDetailDTO
    {
        public double DistanceInKm { get; set; }

        public double FuelNeeded { get; set; }

        public FlightDetailDTO(AirportModel departureAirportModel, AirportModel arrivalAirportModel,
            AircraftModel aircraftModel)
        {

        }
    }
}
