using TUI.Data.Aircrafts.Models;
using TUI.Data.Airports.Models;
using TUI.Data.Common.Managers;

namespace TUI.Data.Flights.Managers
{
    public static class FlightDetailManager
    {
        public static FlightDetail GetFlightDetail(AirportModel departureAirportModel, AirportModel arrivalAirportModel, AircraftModel aircraftModel)
        {
            var detail = new FlightDetail
            {
                DistanceInKm = GPSPositionManager.DistanceInKmBetween(departureAirportModel, arrivalAirportModel)
            };
            detail.FuelNeeded = detail.DistanceInKm * aircraftModel.ConsumptionPerKm + aircraftModel.TakeOffEffort;
            return detail;
        }

        public class FlightDetail
        {
            public double DistanceInKm { get; set; }

            public double FuelNeeded { get; set; }
        }
    }
}
