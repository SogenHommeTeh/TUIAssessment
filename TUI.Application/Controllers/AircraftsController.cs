using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUI.Data.Aircrafts.DTOs;
using TUI.Data.Aircrafts.Managers;
using TUI.Data.Aircrafts.Options;
using TUI.Data.Common.Options;

namespace TUI.Application.Controllers
{
    [Route("aircrafts")]
    public class AircraftsController : Controller
    {
        private readonly AircraftManager _aircraftManager;

        public AircraftsController(AircraftManager aircraftManager)
        {
            _aircraftManager = aircraftManager;
        }

        [HttpGet]
        public IActionResult GetPage([FromQuery]PaginationOptions options)
        {
            return View("AircraftsPage", AircraftDTO.CreatePaginatedDTOs(_aircraftManager.GetPage(options)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AircraftPostOptions options)
        {
            _aircraftManager.Post(options);
            await _aircraftManager.SaveChangesAsync();

            return RedirectToAction("GetPage");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _aircraftManager.DeleteAsync(id);
            await _aircraftManager.SaveChangesAsync();

            return RedirectToAction("GetPage");
        }
    }
}
