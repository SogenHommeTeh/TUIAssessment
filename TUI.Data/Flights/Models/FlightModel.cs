using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Airports.Models;

namespace TUI.Data.Flights.Models
{
    [Table("Flights")]
    public class FlightModel
    {
        [Key]
        public int Id { get; set; }

        public Guid PublicId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int DepartureAirportId { get; set; }
        public virtual AirportModel DepartureAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public int ArrivalAirportId { get; set; }
        public virtual AirportModel ArrivalAirport { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double DistanceInKm { get; set; }

        public int AircraftId { get; set; }
        public virtual AircraftModel Aircraft { get; set; }

        public double FuelNeeded { get; set; }

        public FlightModel()
        {
            PublicId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
