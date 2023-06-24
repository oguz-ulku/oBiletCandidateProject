using DataModels.Constants;
using DataModels.Interfaces;
using DataModels.Model;
using DataModels.Model.Response;

namespace WebAPI.Services
{
    public class UtilityService : IUtilityService
    {

        List<CityModel> cities = new List<CityModel>() {
        new CityModel()
        {
            Id = 1,
            Name = "İstanbul"
        },
          new CityModel()
        {
            Id = 2,
            Name = "Ankara"
        },
            new CityModel()
        {
            Id = 3,
            Name = "İzmir"
        },
              new CityModel()
        {
            Id = 4,
            Name = "Bursa"
        },
                new CityModel()
        {
            Id = 5,
            Name = "Antalya"
        }
        };



        public UtilityService()
        {
            
        }
        public async Task<ApplicationResponse<List<CityModel>>> GetCityList()
        {
            var response = new ApplicationResponse<List<CityModel>>();

            try
            {
                response.Data = cities.ToList();
                response.ResponseCode = GeneralConstant.SuccessCode;
                response.ResponseMessage = GeneralConstant.SuccessMessage;
            }
            catch (Exception ex)
            {

            }

            return await Task.FromResult(response);
        }

        

    }
}
