using DataModels.Model;
using DataModels.Model.Response;

namespace DataModels.Interfaces
{
    public interface IUtilityService
    {
        Task<ApplicationResponse<List<CityModel>>> GetCityList();
    }
}
