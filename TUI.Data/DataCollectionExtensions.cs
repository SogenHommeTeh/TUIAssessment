using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TUI.Data.Aircrafts.Managers;
using TUI.Data.Airports.Managers;
using TUI.Data.Common.Options;
using TUI.Data.Flights.Managers;

namespace TUI.Data
{
    public static class DataCollectionExtensions
    {
        public static IServiceCollection AddDataManager(this IServiceCollection services)
        {
            services.AddTransient<AirportManager>();
            services.AddTransient<AircraftManager>();
            services.AddTransient<FlightManager>();

            return services;
        }

        public static IQueryable<TSource> GetPage<TSource>(this IQueryable<TSource> enumerable, PaginationOptions options = null)
        {
            options = options ?? new PaginationOptions();
            return enumerable
                .Skip((options.PageNumber - 1) * options.PageSize)
                .Take(options.PageSize);
        }
    }
}
