using DataModels.Model;
using DataModels.Model.Response;

namespace DataModels.Interfaces
{
    public interface ISessionService
    {
        Task<ApplicationResponse<SessionResponse>> GetSession(SessionRequest request);
    }
}
