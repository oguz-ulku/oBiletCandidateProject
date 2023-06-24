using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        private readonly IUtilityService _utilityService;
        public UtilityController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        [ProducesResponseType(typeof(ApplicationResponse<List<CityModel>>), StatusCodes.Status200OK)]
        [HttpPost, Route("getCityList")]
        public async Task<IActionResult> GetCityList()
        {
            var response = await _utilityService.GetCityList();
            return Ok(response);
        }

    }
}
