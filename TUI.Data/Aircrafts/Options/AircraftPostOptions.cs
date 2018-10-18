using System.ComponentModel.DataAnnotations;

namespace TUI.Data.Aircrafts.Options
{
    public class AircraftPostOptions
    {
        [Required]
        [MaxLength(128)]
        public string Number { get; set; }

        public double ConsumptionPerKm { get; set; }

        public double TakeOffEffort { get; set; }
    }
}
