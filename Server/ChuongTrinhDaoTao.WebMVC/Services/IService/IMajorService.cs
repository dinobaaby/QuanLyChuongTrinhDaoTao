using ChuongTrinhDaoTao.WebMVC.Models;


namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface IMajorService
    {
        Task<ResponseDto?> GetAllMajorAsync();
        Task<ResponseDto?> GetMajorByIdAsync(int id);
        Task<ResponseDto?> GetMajorByNameAsync(string name);
        Task<ResponseDto?> GetMajorInFacultyAsync(string id);
        Task<ResponseDto?> CreateMajorAsync(MajorDto major);
        Task<ResponseDto?> DeleteMajorAsync(int id);
        Task<ResponseDto?> UpdateMajorAsync(MajorDto major);
    } 
}
