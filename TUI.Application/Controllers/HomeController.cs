using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TUI.Application.Models;
using TUI.Data.Airports.Managers;
using TUI.Data.Common.Options;

namespace TUI.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly AirportManager _airportManager;

        public HomeController(AirportManager airportManager)
        {
            _airportManager = airportManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page. ";
            ViewData["Message"] += JsonConvert.SerializeObject(_airportManager.GetPage(new PaginationOptions()));

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
