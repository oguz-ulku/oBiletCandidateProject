using DataModels.Constants;
using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using DataModels.Others;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Exceptions;

namespace WebAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRedisCacheService _redisCacheService;
        private readonly IHttpService _httpService;
        private readonly ApplicationSettings _config;
        private string _baseUrl;
        public LocationService(IHttpService httpService, IOptions<ApplicationSettings> config,
            IRedisCacheService redisCacheService)
        {
            _httpService = httpService;
            _config = config.Value;
            _baseUrl = config.Value.BaseUrl;
            _redisCacheService = redisCacheService;
        }
        public async Task<ApplicationResponse<List<BusLocationModel>>> GetBusLocations(ApiRequest<string> request)
        {
            var response = new ApplicationResponse<List<BusLocationModel>>();
            try
            {
                var cache = await _redisCacheService.GetAsync<ApplicationResponse<List<BusLocationModel>>>("BusLocations");

                if(cache != null && cache.Data.Count > 0)
                {
                    if(request != null && !string.IsNullOrEmpty(request.Data))
                    {
                        response = cache;
                        response.Data = cache.Data.Where(x => x.Name.ToLower().Contains(request.Data)).ToList();
                    }
                    else
                        response = cache;
                }
                else
                {
                    response = await _httpService.Post<ApplicationResponse<List<BusLocationModel>>>(_baseUrl + _config.GetBusLocationsUrl, request);
                    if (response != null && GeneralConstant.SuccessStatus.Equals(response.Status))
                        await _redisCacheService.SetAsync("BusLocations", response);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(response);
        }

        public async Task<ApplicationResponse<List<BusLocationModel>>> GetDefaultCityList(ApiRequest<string> request)
        {
            string[] defaultLocationParams = { "İstanbul Avrupa", "İstanbul Anadolu", "Ankara", "İzmir", "Bursa", "Antalya" };

            var response = new ApplicationResponse<List<BusLocationModel>>();
            try
            {
                var cache = await _redisCacheService.GetAsync<ApplicationResponse<List<BusLocationModel>>>("BusLocations");

                if (cache != null && cache.Data.Count > 0)
                {
                    response = cache;
                    response.Data = cache.Data.Where(x => defaultLocationParams.Contains(x.Name)).ToList();
                }
                else
                {
                    request.Data = null;
                    response = await _httpService.Post<ApplicationResponse<List<BusLocationModel>>>(_baseUrl + _config.GetBusLocationsUrl, request);
                    if (response != null && GeneralConstant.SuccessStatus.Equals(response.Status))
                    {
                        await _redisCacheService.SetAsync("BusLocations", response);
                        response.Data = response.Data.Where(x => defaultLocationParams.Contains(x.Name)).ToList();
                    }
                       
                }

                

            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(response);
        }
    }
}
