using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IBaseService _baseService;

        public FacultyService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> GetAllFacultyAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Faculties"

            });
        }
        public async Task<ResponseDto> CreateFacultyAsync(FacultyDto facultyDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = facultyDto,
                Url = SD.ApiBase + "/api/Faculties"

            });
        }

        public async Task<ResponseDto> DeleteFacultyAsync(string id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ApiBase + "/api/Faculties/" + id

            }, false);
        }


        public async Task<ResponseDto> GetFacultyByIdAsync(string id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/Faculties/" + id
            }, false);
        }

        public async Task<ResponseDto> UpdateFacultyAsync(FacultyDto facultyDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = facultyDto,
                Url = SD.ApiBase + "/api/Faculties"

            });
        }
        
    }
}
