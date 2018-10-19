using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUI.Data.Airports.DTOs;
using TUI.Data.Airports.Managers;
using TUI.Data.Airports.Options;
using TUI.Data.Common.Options;

namespace TUI.Application.Controllers
{
    [Route("airports")]
    public class AirportsController : Controller
    {
        private readonly AirportManager _airportManager;

        public AirportsController(AirportManager airportManager)
        {
            _airportManager = airportManager;
        }

        [HttpGet]
        public IActionResult GetPage([FromQuery]PaginationOptions options)
        {
            return View("AirportsPage", AirportDTO.CreatePaginatedDTOs(_airportManager.GetPage(options)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AirportPostOptions options)
        {
            _airportManager.Post(options);
            await _airportManager.SaveChangesAsync();

            return RedirectToAction("GetPage");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _airportManager.DeleteAsync(id);
            await _airportManager.SaveChangesAsync();

            return RedirectToAction("GetPage");
        }
    }
}
