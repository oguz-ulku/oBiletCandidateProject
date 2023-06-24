using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using DataModels.Others;
using Microsoft.Extensions.Options;

namespace WebAPI.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly IHttpService _httpService;
        private readonly ApplicationSettings _config;
        private string _baseUrl;
        public JourneyService(IHttpService httpService, IOptions<ApplicationSettings> config)
        {
            _httpService = httpService;
            _config = config.Value;
            _baseUrl = config.Value.BaseUrl;
        }
        public async Task<ApplicationResponse<List<BusJourneyModel>>> GetBusJourneys(ApiRequest<BusJourneyRequest> request)
        {
            var response = new ApplicationResponse<List<BusJourneyModel>>();

            try
			{
                response = await _httpService.Post<ApplicationResponse<List<BusJourneyModel>>>(_baseUrl + _config.GetJorneysUrl, request);
			}
			catch (Exception ex)
			{

				throw;
			}

            return response;
        }
    }
}
