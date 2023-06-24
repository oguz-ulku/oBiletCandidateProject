using DataModels.Constants;
using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using DataModels.Others;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WebUI.Utils;

namespace WebUI.Services
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

            return await Task.FromResult(response);
        }

        public async Task<List<BusJourneyModel>> BusJourneys(BusJourneyRequest request)
        {
            var response = new List<BusJourneyModel>();
            var restRequest = new ApiRequest<BusJourneyRequest>();
            try
            {
                request.DepartureDate = Utility.GetFormattedDate(request.DepartureDate);
                restRequest.Data = request;
                restRequest.Language = GeneralConstant.Turkish;
                restRequest.Date = new DateTime().ToString();
                restRequest.DeviceSession = new DeviceSessionModel
                {
                    DeviceId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA=",
                    SessionId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA="
                };

                var restOut = await GetBusJourneys(restRequest);

                if (restOut != null && GeneralConstant.SuccessStatus.Equals(restOut.Status))
                    response = restOut.Data;
            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(response);
        }
    }
}
