using System;
using System.Linq;
using System.Threading.Tasks;
using TUI.Data.Aircrafts.Models;
using TUI.Data.Aircrafts.Options;
using TUI.Data.Airports.Models;
using TUI.Data.Airports.Options;
using TUI.Data.Common.Managers;
using TUI.Data.Flights.Managers;
using TUI.Data.Flights.Options;
using Xunit;

namespace TUI.Data.Test
{
    public class FlightTest : IClassFixture<FlightFixture>
    {
        private readonly FlightFixture _fixture;

        public FlightTest(FlightFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_Flight_List_Be_Empty()
        {
            _fixture.EmptyDatabase();

            Assert.Equal(0, _fixture.FlightManager.GetPage().Data.Count());
        }

        [Fact]
        public async Task Should_Get_One_Then_Three_Flights()
        {
            _fixture.EmptyDatabase();

            var now = DateTime.UtcNow;
            var options = new FlightPostOptions
            {
                DepartureAirportId = _fixture.SeedAirport(new AirportPostOptions { Name = "Departure" }).PublicId,
                DepartureTime = now.AddDays(1),
                ArrivalAirportId = _fixture.SeedAirport(new AirportPostOptions { Name = "Arrival" }).PublicId,
                ArrivalTime = now.AddDays(1).AddHours(5),
                AircraftId = _fixture.SeedAircraft(new AircraftPostOptions { Number = "0001" }).PublicId,
            };
            await _fixture.FlightManager.PostAsync(options);
            _fixture.FlightManager.SaveChanges();
            
            Assert.Equal(1, _fixture.FlightManager.GetPage().Data.Count());

            options.DepartureTime = now.AddDays(2);
            options.ArrivalTime = options.DepartureTime.AddHours(5);
            await _fixture.FlightManager.PostAsync(options);
            options.DepartureTime = now.AddDays(3);
            options.ArrivalTime = options.DepartureTime.AddHours(5);
            await _fixture.FlightManager.PostAsync(options);
            _fixture.FlightManager.SaveChanges();
            
            Assert.Equal(3, _fixture.FlightManager.GetPage().Data.Count());
        }

        [Fact]
        public async Task Should_Get_One_Then_Zero_Flight()
        {
            _fixture.EmptyDatabase();

            var now = DateTime.UtcNow;
            var options = new FlightPostOptions
            {
                DepartureAirportId = _fixture.SeedAirport(new AirportPostOptions { Name = "Departure" }).PublicId,
                DepartureTime = now.AddDays(1),
                ArrivalAirportId = _fixture.SeedAirport(new AirportPostOptions { Name = "Arrival" }).PublicId,
                ArrivalTime = now.AddDays(1).AddHours(5),
                AircraftId = _fixture.SeedAircraft(new AircraftPostOptions { Number = "0001" }).PublicId,
            };
            var model = await _fixture.FlightManager.PostAsync(options);
            _fixture.FlightManager.SaveChanges();

            Assert.Equal(1, _fixture.FlightManager.GetPage().Data.Count());

            await _fixture.FlightManager.DeleteAsync(model.PublicId);
            _fixture.FlightManager.SaveChanges();

            Assert.Equal(0, _fixture.FlightManager.GetPage().Data.Count());
        }

        [Fact]
        public void Should_Compute_Flight_Detail()
        {
            var departureAirport = new AirportModel
            {
                Name = "CDG",
                Latitude = 49.009719,
                Longitude = 2.547667,
            };
            var arrivalAirport = new AirportModel
            {
                Name = "Jönköpings Flygplats",
                Latitude = 57.750359,
                Longitude = 14.070648,
            };
            var aircraft = new AircraftModel
            {
                ConsumptionPerKm = 50,
                TakeOffEffort = 100,
            };

            var detail = FlightDetailManager.GetFlightDetail(departureAirport, arrivalAirport, aircraft);

            Assert.Equal(1234.03, Math.Round(detail.DistanceInKm, 2));
            Assert.Equal(61801.68, Math.Round(detail.FuelNeeded, 2));
        }
    }
}
