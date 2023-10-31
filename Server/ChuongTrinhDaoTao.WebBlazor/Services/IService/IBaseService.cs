using ChuongTrinhDaoTao.WebBlazor.Models.Dto;

namespace ChuongTrinhDaoTao.WebBlazor.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
