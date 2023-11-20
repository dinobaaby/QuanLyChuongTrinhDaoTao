using WebMachineLearning.Models;
using WebMachineLearning.Services.IService;
using WebMachineLearning.Utilyty;

namespace WebMachineLearning.Services
{
    public class DiabetesService : IDiebetesService
    {
        private readonly IBaseService _baseService;
        public DiabetesService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> TestData(DiaBetes dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.ApiBase + "/api/Diabetes/predict"
            });
        }
    }
}
