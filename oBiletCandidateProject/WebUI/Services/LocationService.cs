using DataModels.Constants;
using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using DataModels.Others;
using Microsoft.Extensions.Options;

namespace WebUI.Services
{
    public class LocationService : ILocationService
    {
        private readonly IHttpService _httpService;
        private readonly ApplicationSettings _config;
        private string _baseUrl;
        public LocationService(IHttpService httpService, IOptions<ApplicationSettings> config)
        {
            _httpService = httpService;
            _config = config.Value;
            _baseUrl = config.Value.BaseUrl;
        }
        public async Task<ApplicationResponse<List<BusLocationModel>>> GetBusLocations(ApiRequest<string> request)
        {
			var response = new ApplicationResponse<List<BusLocationModel>>();

            try
			{
                response = await _httpService.Post<ApplicationResponse<List<BusLocationModel>>>(_baseUrl + _config.GetBusLocationsUrl, request);
			}
			catch (Exception ex)
			{

				throw;
			}

            return await Task.FromResult(response);
        }

        public async Task<ApplicationResponse<List<BusLocationModel>>> GetDefaultCityList(ApiRequest<string> request)
        {
            var response = new ApplicationResponse<List<BusLocationModel>>();

            try
            {
                response = await _httpService.Post<ApplicationResponse<List<BusLocationModel>>>(_baseUrl + _config.GetDefaultCityListUrl, request);
            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(response);
        }

        public async Task<List<BusLocationModel>> DefaultCityList()
        {
            List<BusLocationModel> response = new List<BusLocationModel>();
            ApiRequest<string> request = new ApiRequest<string>();
            try
            {
                request.Data = null;
                request.Language = GeneralConstant.Turkish;
                request.Date = new DateTime().ToString();
                request.DeviceSession = new DeviceSessionModel
                {
                    DeviceId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA=",
                    SessionId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA="
                };

                var restOut = await GetDefaultCityList(request);

                if (restOut != null && GeneralConstant.SuccessStatus.Equals(restOut.Status))
                    response = restOut.Data;
            }
            catch (Exception)
            {

                throw;
            }

            return await Task.FromResult(response);
        }

        public async Task<List<BusLocationModel>> BusLocationList(string keyword)
        {
            List<BusLocationModel> response = new List<BusLocationModel>();
            ApiRequest<string> request = new ApiRequest<string>();
            try
            {
                request.Data = keyword;
                request.Language = GeneralConstant.Turkish;
                request.Date = new DateTime().ToString();
                request.DeviceSession = new DeviceSessionModel
                {
                    DeviceId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA=",
                    SessionId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA="
                };

                var restOut = await GetBusLocations(request);

                if (restOut != null && GeneralConstant.SuccessStatus.Equals(restOut.Status))
                    response = restOut.Data;
            }
            catch (Exception)
            {

                throw;
            }

            return await Task.FromResult(response);
        }
    }
}
