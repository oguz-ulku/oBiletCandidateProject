using DataModels.Model;
using DataModels.Model.Response;

namespace DataModels.Interfaces
{
    public interface ILocationService
    {
        Task<ApplicationResponse<List<BusLocationModel>>> GetBusLocations(ApiRequest<string> request);
        Task<ApplicationResponse<List<BusLocationModel>>> GetDefaultCityList(ApiRequest<string> request);
    }
}
