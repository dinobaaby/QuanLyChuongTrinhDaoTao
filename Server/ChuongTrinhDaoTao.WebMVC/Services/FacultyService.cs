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

        public Task<ResponseDto> GetFacultyAsync(string facultyname)
        {
            throw new NotImplementedException();
        }
    }
}
