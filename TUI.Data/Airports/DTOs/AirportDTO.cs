using System;
using TUI.Data.Airports.Models;
using TUI.Data.Common.DTOs;

namespace TUI.Data.Airports.DTOs
{
    public class AirportDTO : DTO<AirportDTO, AirportModel>
    {
        public Guid PublicId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public override void AssignFromModel(AirportModel model)
        {
            PublicId = model.PublicId;
            CreatedAt = model.CreatedAt;
            Name = model.Name;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
        }
    }
}
