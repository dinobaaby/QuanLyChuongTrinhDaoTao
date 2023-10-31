using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTaoDaiHoc.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> AssignRoleAsync(RegisterationRequestDto assignationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = assignationRequestDto,
               
            });
        }

        public Task<ResponseDto> LoginAsync(LoginRequestDto loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> RegisterAsync(RegisterationRequestDto registerationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
