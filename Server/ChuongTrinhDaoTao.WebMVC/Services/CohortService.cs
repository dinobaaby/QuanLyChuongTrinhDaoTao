using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class CohortService : ICohortService
    {
        private readonly IBaseService _baseService;
        public CohortService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreatesAsync(CohortDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.ApiBase + "/api/Cohort/CohortWithMajor"
            });
        }

      

        public async Task<ResponseDto?> DeleteAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ApiBase + "/api/Cohort/" + id
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Cohort"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Cohort/" + id
            });
        }

        public Task<ResponseDto?> GetByNameAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> UpdateAsync(CohortDto dto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.ApiBase + "/api/Cohort" 
            });
        }
    }
}
