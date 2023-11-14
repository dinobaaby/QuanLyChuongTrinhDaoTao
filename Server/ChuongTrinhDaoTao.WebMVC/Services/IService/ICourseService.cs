using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface ICourseService
    {
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetByIdAsync(int id);
        Task<ResponseDto?> CreateAsync(CourseDto course);
        Task<ResponseDto?> UpdateAsync(CourseDto course);
        Task<ResponseDto?> DeleteAsync(int id);
        Task<ResponseDto?> GetByNameAsync(string name);
    }
}
