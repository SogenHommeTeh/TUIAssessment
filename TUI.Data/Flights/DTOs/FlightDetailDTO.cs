using TUI.Data.Aircrafts.Models;
using TUI.Data.Airports.Models;

namespace TUI.Data.Flights.DTOs
{
    public class FlightDetailDTO
    {
        public double DistanceInKm { get; set; }

        public double FuelNeeded { get; set; }

        public FlightDetailDTO(AirportModel departureAirportModel, AirportModel arrivalAirportModel,
            AircraftModel aircraftModel)
        {
            DistanceInKm = departureAirportModel.DistanceInKmTo(arrivalAirportModel);
            FuelNeeded = DistanceInKm * aircraftModel.ConsumptionPerKm + aircraftModel.TakeOffEffort;
        }
    }
}
