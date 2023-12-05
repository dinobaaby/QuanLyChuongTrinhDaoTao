using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class TuitionTypeService : ITuitionTypeService
    {
        private readonly IBaseService _baseService;
        public TuitionTypeService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(TuitionTypeDto tuitionTypeDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = tuitionTypeDto,
                Url = SD.ApiBase + "/api/TuitionTypes"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ApiBase + "/api/TuitionTypes/" + id
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/TuitionTypes"
            });
        }

        public async Task<ResponseDto?> GetAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/TuitionTypes/" + id
            });
        }

        public async Task<ResponseDto?> UpdateAsync(TuitionTypeDto tuitionTypeDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = tuitionTypeDto,
                Url = SD.ApiBase + "/api/TuitionTypes"
            });
        }
    }
}
