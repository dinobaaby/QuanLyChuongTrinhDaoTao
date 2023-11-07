using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface IFacultyService
    {
        Task<ResponseDto> GetFacultyAsync(string facultyname);
        Task<ResponseDto> GetAllFacultyAsync();
    }
}
