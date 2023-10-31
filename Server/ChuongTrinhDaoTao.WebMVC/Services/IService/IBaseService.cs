using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
