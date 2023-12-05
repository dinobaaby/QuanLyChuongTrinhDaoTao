using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface ITuitionCTDTService
    {
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> CreateAsync(TuitionCTDTDto dto);
        Task<ResponseDto?> DeleteAsync(int tuitionId, int majorId, int cohortId);
    }
}
