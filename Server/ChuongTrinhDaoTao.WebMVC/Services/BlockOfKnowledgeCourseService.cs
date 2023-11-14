using ChuongTrinhDaoTao.WebMVC.Model;
using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class BlockOfKnowledgeCourseService : IBlockOfKnowledgeCourseService
    {
        private readonly IBaseService _baseService;

        public BlockOfKnowledgeCourseService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ChiTietChuongTrinhDaiHocAsync(int majorId, int cohortId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/BlockOfKnowledgeCourses/ChiTietChuongtrinhDaoTao/" + majorId + "/" + cohortId
            });
        }

        public async Task<ResponseDto?> CreateAsync(BlockOfKnowledge_Course block)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = block,
                Url = SD.ApiBase + "/api/BlockOfKnowledgeCourses"
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/BlockOfKnowledgeCourses"
            });
        }
    }
}
