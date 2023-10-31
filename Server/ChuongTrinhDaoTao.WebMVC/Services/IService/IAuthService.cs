using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequest);
        Task<ResponseDto> RegisterAsync(RegisterationRequestDto registerationRequestDto);
        Task<ResponseDto> AssignRoleAsync(RegisterationRequestDto assignationRequestDto);


    }
}
