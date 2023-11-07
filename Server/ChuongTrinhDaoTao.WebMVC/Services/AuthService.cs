using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;
using NuGet.Protocol.Plugins;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        

       

        public async Task<ResponseDto?> AssignRoleAsync(RegisterationRequestDto assignRoleRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = assignRoleRequestDto,
                Url = SD.ApiBase + "/api/Auth/AssignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.ApiBase + "/api/Auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegisterationRequestDto registerationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registerationRequestDto,
                Url = SD.ApiBase + "/api/Auth/Re"
            }, withBearer: false);
        }
    }
}
