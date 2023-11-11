using ChuongTrinhDaoTao.WebMVC.Model;
using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class BlockOfKnowledgeService : IBlockOfKnowledgeService
    {
        private readonly IBaseService _baseService;
        public BlockOfKnowledgeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateAsync(BlockOfKnowledgeDto blockOfKnowledgeDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = blockOfKnowledgeDto,
                Url = SD.ApiBase + "/api/BlockOfKnowledge"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ApiBase + "/api/BlockOfKnowledge/" + id
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/BlockOfKnowledge"
            });
        }

        public async Task<ResponseDto?> GetByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/BlockOfKnowledge/" + id
            });
        }

        public async Task<ResponseDto?> UpdateAsync(BlockOfKnowledgeDto blockOfKnowledgeDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = blockOfKnowledgeDto,
                Url = SD.ApiBase + "/api/BlockOfKnowledge"
            });
        }
    }
}
