using ChuongTrinhDaoTao.WebBlazor.Models.Dto;
using ChuongTrinhDaoTao.WebBlazor.Services.IService;

namespace ChuongTrinhDaoTao.WebBlazor.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            throw new NotImplementedException();
        }
    }
}
