using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class MajorService : IMajorService
    {
        private readonly IBaseService _baseService;
        public MajorService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateMajorAsync(MajorDto major)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = major,
                Url = SD.ApiBase + "/api/Major"
            });
        }

        public async Task<ResponseDto?> DeleteMajorAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE, 
                Url = SD.ApiBase + "/api/Major/" +id
            });
        }

        public async Task<ResponseDto?> GetAllMajorAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Major"
            });
        }

        public async Task<ResponseDto?> GetMajorByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Major/" + id
            }, false);
        }

        public async Task<ResponseDto?> GetMajorByNameAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Major/GetByName/" + name
            });
        }

        public async Task<ResponseDto?> GetMajorInFacultyAsync(string id)
        {
            
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Major/MajorInFaculty/" + id
            });
        }

        public async Task<ResponseDto?> UpdateMajorAsync(MajorDto major)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = major,
                Url = SD.ApiBase + "/api/Major"
                
            });
        }
    }
}
