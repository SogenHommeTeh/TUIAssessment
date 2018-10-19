using System;
using System.Collections.Generic;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Common.DTOs;
using TUI.Data.Flights.DTOs;

namespace TUI.Data.Aircrafts.DTOs
{
    public class AircraftDTO : DTO<AircraftDTO, AircraftModel>
    {
        public Guid PublicId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Number { get; set; }

        public double ConsumptionPerKm { get; set; }

        public double TakeOffEffort { get; set; }

        public virtual IEnumerable<FlightDTO> Flights { get; set; }

        public override void AssignFromModel(AircraftModel model)
        {
            PublicId = model.PublicId;
            CreatedAt = model.CreatedAt;
            Number = model.Number;
            ConsumptionPerKm = model.ConsumptionPerKm;
            TakeOffEffort = model.TakeOffEffort;
            Flights = FlightDTO.CreateDTOs(model.Flights);
        }
    }
}
