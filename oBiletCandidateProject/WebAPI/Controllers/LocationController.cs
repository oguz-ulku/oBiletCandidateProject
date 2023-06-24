using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [ProducesResponseType(typeof(ApplicationResponse<BusLocationModel>), StatusCodes.Status200OK)]
        [HttpPost, Route("getBusLocationSearch")]
        public async Task<IActionResult> GetBusLocationSearch([FromBody] ApiRequest<string> request)
        {
            var response = await _locationService.GetBusLocations(request);
            return Ok(response);
        }

        [ProducesResponseType(typeof(ApplicationResponse<BusLocationModel>), StatusCodes.Status200OK)]
        [HttpPost, Route("getDefaultCityList")]
        public async Task<IActionResult> GetDefaultCityList([FromBody] ApiRequest<string> request)
        {
            var response = await _locationService.GetDefaultCityList(request);
            return Ok(response);
        }
    }
}
