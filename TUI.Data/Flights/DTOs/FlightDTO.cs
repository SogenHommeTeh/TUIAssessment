using System;
using TUI.Data.Airports.DTOs;
using TUI.Data.Airports.Options;
using TUI.Data.Common.DTOs;
using TUI.Data.Flights.Models;

namespace TUI.Data.Flights.DTOs
{
    public class FlightDTO : DTO<FlightDTO, FlightModel>
    {
        public Guid PublicId { get; set; }

        public DateTime CreatedAt { get; set; }

        public AirportDTO DepartureAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public AirportDTO ArrivalAirport { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double DistanceInKm { get; set; }

        public AircraftDTO Aircraft { get; set; }

        public double FuelNeeded { get; set; }

        public override void AssignFromModel(FlightModel model)
        {
            PublicId = model.PublicId;
            CreatedAt = model.CreatedAt;
            DepartureAirport = AirportDTO.CreateDTO(model.DepartureAirport);
            DepartureTime = model.DepartureTime;
            ArrivalAirport = AirportDTO.CreateDTO(model.ArrivalAirport);
            ArrivalTime = model.ArrivalTime;
            DistanceInKm = model.DistanceInKm;
            Aircraft = AircraftDTO.CreateDTO(model.Aircraft);
            FuelNeeded = model.FuelNeeded;
        }
    }
}
