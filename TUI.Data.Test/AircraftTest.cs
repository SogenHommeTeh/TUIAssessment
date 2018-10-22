using System.Linq;
using System.Threading.Tasks;
using TUI.Data.Aircrafts.Options;
using Xunit;

namespace TUI.Data.Test
{
    public class AircraftTest : IClassFixture<AircraftFixture>
    {
        private readonly AircraftFixture _fixture;

        public AircraftTest(AircraftFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_Aircraft_List_Be_Empty()
        {
            _fixture.EmptyDatabase();

            Assert.Equal(0, _fixture.AircraftManager.GetPage().Data.Count());
        }

        [Fact]
        public void Should_Get_One_Then_Three_Aircrafts()
        {
            _fixture.EmptyDatabase();

            var options = new AircraftPostOptions
            {
                Number = "0001",
            };
            _fixture.AircraftManager.Post(options);
            _fixture.AircraftManager.SaveChanges();

            Assert.Equal(1, _fixture.AircraftManager.GetPage().Data.Count());

            options.Number = "0002";
            _fixture.AircraftManager.Post(options);
            options.Number = "0003";
            _fixture.AircraftManager.Post(options);
            _fixture.AircraftManager.SaveChanges();

            Assert.Equal(3, _fixture.AircraftManager.GetPage().Data.Count());
        }

        [Fact]
        public async Task Should_Get_One_Then_Zero_Aircraft()
        {
            _fixture.EmptyDatabase();

            var options = new AircraftPostOptions
            {
                Number = "0001",
            };
            var model = _fixture.AircraftManager.Post(options);
            _fixture.AircraftManager.SaveChanges();

            Assert.Equal(1, _fixture.AircraftManager.GetPage().Data.Count());

            await _fixture.AircraftManager.DeleteAsync(model.PublicId);
            _fixture.AircraftManager.SaveChanges();

            Assert.Equal(0, _fixture.AircraftManager.GetPage().Data.Count());
        }
    }
}
