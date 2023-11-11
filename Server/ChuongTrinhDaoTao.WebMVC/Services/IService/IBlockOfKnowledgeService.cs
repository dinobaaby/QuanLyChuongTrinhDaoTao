using ChuongTrinhDaoTao.WebMVC.Model;
using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface IBlockOfKnowledgeService
    {
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> CreateAsync(BlockOfKnowledgeDto blockOfKnowledgeDto);
        Task<ResponseDto?> UpdateAsync(BlockOfKnowledgeDto blockOfKnowledgeDto);
        Task<ResponseDto?> DeleteAsync(int id);
        Task<ResponseDto?> GetByIdAsync(int id);
    }
}
