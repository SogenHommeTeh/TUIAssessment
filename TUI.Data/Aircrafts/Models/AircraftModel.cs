using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TUI.Data.Flights.Models;

namespace TUI.Data.Aircrafts.Models
{
    [Table("Aircrafts")]
    public class AircraftModel
    {
        [Key]
        public int Id { get; set; }

        public Guid PublicId { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(128)]
        public string Number { get; set; }

        public double ConsumptionPerKm { get; set; }

        public double TakeOffEffort { get; set; }

        public virtual IEnumerable<FlightModel> Flights { get; set; }

        public AircraftModel()
        {
            PublicId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
