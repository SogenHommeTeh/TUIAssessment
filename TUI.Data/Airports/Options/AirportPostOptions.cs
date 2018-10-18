using System.ComponentModel.DataAnnotations;
using TUI.Data.Common.Options;

namespace TUI.Data.Airports.Options
{
    public class AirportPostOptions : GPSPositionOptions
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
