using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }


        [ProducesResponseType(typeof(ApplicationResponse<List<BusJourneyModel>>), StatusCodes.Status200OK)]
        [HttpPost, Route("getJourneys")]
        public async Task<IActionResult> GetJourneys([FromBody] ApiRequest<BusJourneyRequest> request)
        {
            var response = await _journeyService.GetBusJourneys(request);
            return Ok(response);
        }
    }
}
