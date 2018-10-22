using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
using TUI.Data.Airports.Models;
using TUI.Data.Airports.Options;
using TUI.Data.Common.Managers;
using TUI.Data.Common.Options;
using TUI.Data.Common.Models;
using TUI.Error.Exceptions;

namespace TUI.Data.Airports.Managers
{
    public class AirportManager : BaseDbManager<ApplicationDbContext>
    {
        public AirportManager(ApplicationDbContext context, TelemetryClient telemetryClient) : base(context, telemetryClient)
        {
        }

        public PageModel<AirportModel> GetPage(PaginationOptions options = null)
        {
            var models = Context.Airports.OrderBy(airport => airport.Name);

            return new PageModel<AirportModel>(options, models.AsNoTracking());
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

        public async Task DeleteAsync(Guid publicId)
        {
            var model = await Context.Airports.FirstOrDefaultAsync(aircraft => aircraft.PublicId == publicId);
            if (model == null) throw new NotFoundException();

            Context.Airports.Remove(model);
        }
    }
}
