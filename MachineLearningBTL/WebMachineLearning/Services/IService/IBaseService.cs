using WebMachineLearning.Models;

namespace WebMachineLearning.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true) ;
    }
}
