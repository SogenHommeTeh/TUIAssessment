using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TUI.Data.Common.Models;
using TUI.Data.Flights.Models;

namespace TUI.Data.Airports.Models
{
    [Table("Airports")]
    public class AirportModel : GPSPositionModel
    {
        [Key]
        public int Id { get; set; }

        public Guid PublicId { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public virtual IEnumerable<FlightModel> DepartureFlights { get; set; }
        public virtual IEnumerable<FlightModel> ArrivalFlights { get; set; }

        public AirportModel()
        {
            PublicId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
