using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface ITuitionService
    {
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> CreateAsync(TuitionDto tuitionDto);
        Task<ResponseDto?> UpdateAsync(TuitionDto tuitionDto);
        Task<ResponseDto?> DeleteAsync(int id);
        Task<ResponseDto?> GetAsync(int id);
    }
}
