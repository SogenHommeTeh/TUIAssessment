using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
using TUI.Data.Common.Managers;
using TUI.Data.Common.Options;
using TUI.Data.Common.Utils;
using TUI.Data.Flights.DTOs;
using TUI.Data.Flights.Models;
using TUI.Data.Flights.Options;
using TUI.Error.Exceptions;

namespace TUI.Data.Flights.Managers
{
    public class FlightManager : BaseDbManager<ApplicationDbContext>
    {
        public FlightManager(ApplicationDbContext context, TelemetryClient telemetryClient) : base(context, telemetryClient)
        {
        }
        
        public PageModel<FlightModel> GetPage(PaginationOptions options = null)
        {
            var models = Context.Flights
                .Include(flight => flight.DepartureAirport)
                .Include(flight => flight.ArrivalAirport)
                .Include(flight => flight.Aircraft)
                .OrderByDescending(flight => flight.DepartureTime);

            return new PageModel<FlightModel>(options, models.AsNoTracking());
        }

        public async Task<FlightModel> PostAsync(FlightPostOptions options)
        {
            var departureAirportModel = await Context.Airports.FirstOrDefaultAsync(airport => airport.PublicId == options.DepartureAirportId);
            if (departureAirportModel == null) throw new NotFoundException();
            var arrivalAirportModel = await Context.Airports.FirstOrDefaultAsync(airport => airport.PublicId == options.ArrivalAirportId);
            if (arrivalAirportModel == null) throw new NotFoundException();
            var aircraftModel = await Context.Aircrafts.FirstOrDefaultAsync(aircraft => aircraft.PublicId == options.AircraftId);
            if (aircraftModel == null) throw new NotFoundException();
            var isFlying = Context.Flights.Any(flight => flight.AircraftId == aircraftModel.Id &&
                                                         flight.DepartureTime <= DateTime.UtcNow &&
                                                         flight.ArrivalTime >= DateTime.UtcNow);
            if (isFlying) throw new AircraftAlreadyFlyingException();

            var detail = new FlightDetailDTO(departureAirportModel, arrivalAirportModel, aircraftModel);
            var model = new FlightModel
            {
                DepartureAirport = departureAirportModel,
                DepartureTime = options.DepartureTime.ToUniversalTime(),
                ArrivalAirport = arrivalAirportModel,
                ArrivalTime = options.ArrivalTime.ToUniversalTime(),
                Aircraft = aircraftModel,
                DistanceInKm = detail.DistanceInKm,
                FuelNeeded = detail.FuelNeeded,
            };

            Context.Flights.Add(model);

            return model;
        }

        public async Task DeleteAsync(Guid publicId)
        {
            var model = await Context.Flights.FirstOrDefaultAsync(aircraft => aircraft.PublicId == publicId);
            if (model == null) throw new NotFoundException();

            Context.Flights.Remove(model);
        }
    }
}
