using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;

namespace TUI.Data.Common.Managers
{
    public class BaseDbManager<TDbContext> : BaseManager where TDbContext : DbContext
    {
        protected readonly TDbContext Context;

        public BaseDbManager(TDbContext context, TelemetryClient telemetryClient) : base(telemetryClient)
        {
            Context = context;
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
