using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface IFacultyService
    {
     
        Task<ResponseDto> GetAllFacultyAsync();
        Task<ResponseDto> GetFacultyByIdAsync(string id);
        Task<ResponseDto> CreateFacultyAsync(FacultyDto facultyDto);
        Task<ResponseDto> UpdateFacultyAsync(FacultyDto facultyDto);
        Task<ResponseDto?> DeleteFacultyAsync(string id);
    }
}
