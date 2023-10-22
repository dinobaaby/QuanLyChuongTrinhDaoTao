using ChuongTrinhDaoTao.Service.WebApi.Data;
using ChuongTrinhDaoTao.Service.WebApi.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace ChuongTrinhDaoTao.Service.WebApi.Services.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterationRequestDto requestDto);
        Task<LoginResponseDto> Login(LoginRequestDto requestDto);
        Task<bool> AssignRole(string email, string roleName);
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<bool> ChangePassword(ChangePasswordRequest changePassword);
        Task<bool> ForgotPassword(string email);
        Task<bool> AssignRoleClaim(AssignRoleClaim assignRoleClaim);
        Task<IEnumerable<IdentityRole>> GetAllRole();
    }
}
