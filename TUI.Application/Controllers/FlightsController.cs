using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUI.Data.Flights.DTOs;
using TUI.Data.Flights.Managers;
using TUI.Data.Flights.Options;
using TUI.Data.Common.Options;

namespace TUI.Application.Controllers
{
    [Route("")]
    [Route("flights")]
    public class FlightsController : Controller
    {
        private readonly FlightManager _flightManager;

        public FlightsController(FlightManager flightManager)
        {
            _flightManager = flightManager;
        }

        [HttpGet]
        public IActionResult GetPage([FromQuery]PaginationOptions options)
        {
            return View("FlightsPage", FlightDTO.CreatePaginatedDTOs(_flightManager.GetPage(options)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(FlightPostOptions options)
        {
            await _flightManager.PostAsync(options);
            await _flightManager.SaveChangesAsync();

            return RedirectToAction("GetPage");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _flightManager.DeleteAsync(id);
            await _flightManager.SaveChangesAsync();

            return RedirectToAction("GetPage");
        }
    }
}
