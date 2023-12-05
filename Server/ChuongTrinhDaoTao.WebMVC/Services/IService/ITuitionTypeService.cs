using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface ITuitionTypeService
    {
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> CreateAsync(TuitionTypeDto tuitionTypeDto);
        Task<ResponseDto?> UpdateAsync(TuitionTypeDto tuitionTypeDto);
        Task<ResponseDto?> DeleteAsync(int id);
        Task<ResponseDto?> GetAsync(int id);
    }
}
