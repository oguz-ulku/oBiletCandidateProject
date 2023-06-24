using DataModels.Constants;
using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;
using DataModels.Others;
using Microsoft.Extensions.Options;
using WebAPI.Exceptions;

namespace WebAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly IHttpService _httpService;
        private readonly ApplicationSettings _config;
        private string _baseUrl;
        public SessionService(IHttpService httpService, IOptions<ApplicationSettings> config)
        {
            _httpService = httpService;
            _config = config.Value;
            _baseUrl = config.Value.BaseUrl;
        }
        public async Task<ApplicationResponse<SessionResponse>> GetSession(SessionRequest request)
        {
            var response = new ApplicationResponse<SessionResponse>();
            try
            {
               response = await _httpService.Post<ApplicationResponse<SessionResponse>>(_baseUrl + _config.GetSessionUrl, request);


            }
            catch (ApiException ex)
            {
                
            }

            return await Task.FromResult(response);
        }
    }
}
