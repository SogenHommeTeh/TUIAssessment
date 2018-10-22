using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
using TUI.Data.Aircrafts.Managers;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Aircrafts.Options;
using TUI.Data.Airports.Managers;
using TUI.Data.Airports.Models;
using TUI.Data.Airports.Options;
using TUI.Data.Flights.Managers;

namespace TUI.Data.Test
{
    public class DataFixture
    {
        protected readonly ApplicationDbContext Context;

        public DataFixture(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
            Context = new ApplicationDbContext(options);
        }

        public void EmptyDatabase()
        {
            Context.Database.EnsureDeleted();
        }
    }

    public class AirportFixture : DataFixture
    {
        public AirportManager AirportManager { get; set; }

        public AirportFixture() : base("TUI-Test-Airport")
        {
            var telemetryClient = new TelemetryClient();
            AirportManager = new AirportManager(Context, telemetryClient);
        }
    }

    public class AircraftFixture : DataFixture
    {
        public AircraftManager AircraftManager { get; set; }

        public AircraftFixture() : base("TUI-Test-Aircraft")
        {
            var telemetryClient = new TelemetryClient();
            AircraftManager = new AircraftManager(Context, telemetryClient);
        }
    }

    public class FlightFixture : DataFixture
    {
        public FlightManager FlightManager { get; set; }
        public AirportManager AirportManager { get; set; }
        public AircraftManager AircraftManager { get; set; }

        public FlightFixture() : base("TUI-Test-Flight")
        {
            var telemetryClient = new TelemetryClient();
            FlightManager = new FlightManager(Context, telemetryClient);
            AirportManager = new AirportManager(Context, telemetryClient);
            AircraftManager = new AircraftManager(Context, telemetryClient);
        }

        public AirportModel SeedAirport(AirportPostOptions options)
        {
            var model = AirportManager.Post(options);
            AirportManager.SaveChanges();
            return model;
        }

        public AircraftModel SeedAircraft(AircraftPostOptions options)
        {
            var model = AircraftManager.Post(options);
            AircraftManager.SaveChanges();
            return model;
        }
    }
}
