using ChuongTrinhDaoTao.Service.API.Data;
using ChuongTrinhDaoTao.Service.API.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace ChuongTrinhDaoTao.Service.API.Services.IService
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
