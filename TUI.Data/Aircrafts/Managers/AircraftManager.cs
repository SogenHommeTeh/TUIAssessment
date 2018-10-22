using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Aircrafts.Options;
using TUI.Data.Common.Managers;
using TUI.Data.Common.Options;
using TUI.Data.Common.Models;
using TUI.Error.Exceptions;

namespace TUI.Data.Aircrafts.Managers
{
    public class AircraftManager : BaseDbManager<ApplicationDbContext>
    {
        public AircraftManager(ApplicationDbContext context, TelemetryClient telemetryClient) : base(context, telemetryClient)
        {
        }

        public PageModel<AircraftModel> GetPage(PaginationOptions options = null)
        {
            var models = Context.Aircrafts.OrderBy(aircraft => aircraft.Number);

            return new PageModel<AircraftModel>(options, models.AsNoTracking());
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

        public async Task DeleteAsync(Guid publicId)
        {
            var model = await Context.Aircrafts.FirstOrDefaultAsync(aircraft => aircraft.PublicId == publicId);
            if (model == null) throw new NotFoundException();

            Context.Aircrafts.Remove(model);
        }
    }
}
