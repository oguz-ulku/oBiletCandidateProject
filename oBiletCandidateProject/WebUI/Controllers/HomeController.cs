using DataModels.Interfaces;
using DataModels.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LocationService _locationService;
        private readonly JourneyService _journeyService;

        public HomeController(ILogger<HomeController> logger,
            LocationService locationService, JourneyService journeyService)
        {
            _logger = logger;
            _locationService = locationService;
            _journeyService = journeyService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var response = await _locationService.BusLocationList(null);

            var viewModel = new BusLocationViewModel
            {
                BusLocationItems = response.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                }).ToList()
            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> SearchAsync(string searchValue)
        {

            var response = await _locationService.BusLocationList(searchValue);

            var viewModel = new BusLocationViewModel
            {
                BusLocationItems = response.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                }).ToList()

            };
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult GetBusJourneys(BusLocationViewModel request)
        {

            return RedirectToAction("Journey", "Home", new
            {
                originId = request.JourneyModel.OriginId,
                destinationId = request.JourneyModel.DestinationId,
                departureDate = request.JourneyModel.DepartureDate
            });
        }

        public IActionResult Journey()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> JourneyAsync(BusLocationViewModel request)
        {

            ViewBag.Date = request.JourneyModel.DepartureDate;
            var response = await _journeyService.BusJourneys(request.JourneyModel);

            ViewBag.BackButtonUrl = "/Home/Index";

            ViewBag.Location = response[0].OriginLocation + " - " + response[0].DestinationLocation;
            

            BusJourneyViewModel model = new BusJourneyViewModel
            {
                BusLocationItems = response
            };

            return View("Journey", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}