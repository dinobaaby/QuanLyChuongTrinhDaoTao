using ChuongTrinhDaoTao.WebMVC.Model;
using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface IBlockOfKnowledgeCourseService
    {
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> ChiTietChuongTrinhDaiHocAsync(int majorId, int cohortId);
        Task<ResponseDto?> CreateAsync(BlockOfKnowledge_Course block);
    }
}
