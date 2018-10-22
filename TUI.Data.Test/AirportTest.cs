using System.Linq;
using System.Threading.Tasks;
using TUI.Data.Airports.Options;
using Xunit;

namespace TUI.Data.Test
{
    public class AirportTest : IClassFixture<AirportFixture>
    {
        private readonly AirportFixture _fixture;

        public AirportTest(AirportFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_Airport_List_Be_Empty()
        {
            _fixture.EmptyDatabase();

            Assert.Equal(0, _fixture.AirportManager.GetPage().Data.Count());
        }

        [Fact]
        public void Should_Get_One_Then_Three_Airports()
        {
            _fixture.EmptyDatabase();

            var options = new AirportPostOptions
            {
                Name = "0001",
            };
            _fixture.AirportManager.Post(options);
            _fixture.AirportManager.SaveChanges();

            Assert.Equal(1, _fixture.AirportManager.GetPage().Data.Count());

            options.Name = "0002";
            _fixture.AirportManager.Post(options);
            options.Name = "0003";
            _fixture.AirportManager.Post(options);
            _fixture.AirportManager.SaveChanges();

            Assert.Equal(3, _fixture.AirportManager.GetPage().Data.Count());
        }

        [Fact]
        public async Task Should_Get_One_Then_Zero_Airport()
        {
            _fixture.EmptyDatabase();

            var options = new AirportPostOptions
            {
                Name = "0001",
            };
            var model = _fixture.AirportManager.Post(options);
            _fixture.AirportManager.SaveChanges();

            Assert.Equal(1, _fixture.AirportManager.GetPage().Data.Count());

            await _fixture.AirportManager.DeleteAsync(model.PublicId);
            _fixture.AirportManager.SaveChanges();

            Assert.Equal(0, _fixture.AirportManager.GetPage().Data.Count());
        }
    }
}
