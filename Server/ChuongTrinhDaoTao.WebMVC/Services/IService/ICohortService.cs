using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface ICohortService
    {
        Task<ResponseDto?> GetAllAsync();

        Task<ResponseDto?> UpdateAsync(CohortDto dto);
        Task<ResponseDto?> DeleteAsync(int id);
        Task<ResponseDto?> GetByIdAsync(int id);
        Task<ResponseDto?> CreatesAsync(CohortDto dto);
        Task<ResponseDto?> GetByNameAsync();

    }
}
