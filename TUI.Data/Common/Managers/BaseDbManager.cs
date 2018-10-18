using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;

namespace TUI.Data.Common.Managers
{
    public class BaseDbManager<TDbContext> where TDbContext : DbContext
    {
        protected readonly TDbContext Context;
        protected readonly TelemetryClient TelemetryClient;

        public BaseDbManager(TDbContext context, TelemetryClient telemetryClient)
        {
            Context = context;
            TelemetryClient = telemetryClient;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
