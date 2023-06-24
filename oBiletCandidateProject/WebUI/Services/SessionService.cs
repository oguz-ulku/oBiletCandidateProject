using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;

namespace WebUI.Services
{
    public class SessionService : ISessionService
    {
        public Task<ApplicationResponse<SessionResponse>> GetSession(SessionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
