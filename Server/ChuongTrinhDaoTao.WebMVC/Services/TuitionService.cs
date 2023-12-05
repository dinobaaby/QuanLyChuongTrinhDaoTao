using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class TuitionService : ITuitionService
    {
        private readonly IBaseService _baseService;
        public TuitionService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAsync(TuitionDto tuitionDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = tuitionDto,
                Url = SD.ApiBase + "/api/Tuitions"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ApiBase + "/api/Tuitions/" + id
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Tuitions"
            });
        }

        public async Task<ResponseDto?> GetAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Tuitions/" + id
            });
        }

        public async Task<ResponseDto?> UpdateAsync(TuitionDto tuitionDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = tuitionDto,
                Url = SD.ApiBase + "/api/Tuitions"
            });
        }
    }
}
