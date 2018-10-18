using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
using TUI.Data.Airports.Models;
using TUI.Data.Airports.Options;
using TUI.Data.Common.Managers;
using TUI.Data.Common.Options;
using TUI.Error.Exceptions;

namespace TUI.Data.Airports.Managers
{
    public class AirportManager : BaseDbManager<ApplicationDbContext>
    {
        public AirportManager(ApplicationDbContext context, TelemetryClient telemetryClient) : base(context, telemetryClient)
        {
        }

        public IEnumerable<AirportModel> GetPage(PaginationOptions options)
        {
            var models = Context.Airports.OrderBy(airport => airport.Name);

            return models.AsNoTracking().GetPage(options);
        }

        public AirportModel Post(AirportPostOptions options)
        {
            var model = new AirportModel
            {
                Name = options.Name,
                Latitude = options.Latitude,
                Longitude = options.Longitude,
            };

            Context.Airports.Add(model);

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
