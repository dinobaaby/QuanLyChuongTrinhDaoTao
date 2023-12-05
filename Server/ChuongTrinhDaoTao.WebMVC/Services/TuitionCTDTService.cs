using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class TuitionCTDTService : ITuitionCTDTService
    {
        private readonly IBaseService _baseService;


        public TuitionCTDTService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto?> CreateAsync(TuitionCTDTDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> DeleteAsync(int tuitionId, int majorId, int cohortId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ApiBase + "/api/TuitionCTDTs/" + tuitionId + "/" + majorId +"/" + cohortId
            });
        }

        public  async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/TuitionCTDTs"
            });

        }
    }
}
