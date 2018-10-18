using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Aircrafts.Options;
using TUI.Data.Common.Managers;
using TUI.Data.Common.Options;
using TUI.Error.Exceptions;

namespace TUI.Data.Aircrafts.Managers
{
    public class AircraftManager : BaseDbManager<ApplicationDbContext>
    {
        public AircraftManager(ApplicationDbContext context, TelemetryClient telemetryClient) : base(context, telemetryClient)
        {
        }

        public IEnumerable<AircraftModel> GetPage(PaginationOptions options)
        {
            var models = Context.Aircrafts.OrderBy(aircraft => aircraft.Number)
                .Include(aircraft => aircraft.Flights.Where(flight => flight.DepartureTime <= DateTime.UtcNow &&
                                                                      flight.ArrivalTime >= DateTime.UtcNow));

            return models.AsNoTracking().GetPage(options);
        }

        public AircraftModel Post(AircraftPostOptions options)
        {
            var model = new AircraftModel
            {
                Number = options.Number,
                ConsumptionPerKm = options.ConsumptionPerKm,
                TakeOffEffort = options.TakeOffEffort,
            };

            Context.Aircrafts.Add(model);

            return model;
        }

        public async void DeleteAsync(Guid publicId)
        {
            var model = await Context.Aircrafts.FirstOrDefaultAsync(aircraft => aircraft.PublicId == publicId);
            if (model == null) throw new NotFoundException();

            Context.Aircrafts.Remove(model);
        }
    }
}
