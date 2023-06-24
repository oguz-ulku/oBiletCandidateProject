using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [ProducesResponseType(typeof(ApplicationResponse<SessionResponse>), StatusCodes.Status200OK)]
        [HttpPost, Route("getSession")]
        public async Task<IActionResult> GetSession([FromBody] SessionRequest request)
        {
            var response = await _sessionService.GetSession(request);
            return Ok(response);
        }
    }
}
