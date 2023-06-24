using DataModels.Model;
using DataModels.Model.Response;

namespace DataModels.Interfaces
{
    public interface IJourneyService
    {
        Task<ApplicationResponse<List<BusJourneyModel>>> GetBusJourneys(ApiRequest<BusJourneyRequest> request);
    }
}
