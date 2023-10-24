using ChuongTrinhDaoTao.Service.API.Contants;
using ChuongTrinhDaoTao.Service.API.Data;
using ChuongTrinhDaoTao.Service.API.Models.Dto;
using ChuongTrinhDaoTao.Service.API.Services.IService;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;
using System.Security.Claims;

namespace ChuongTrinhDaoTao.Service.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator =  jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {

                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<bool> AssignRoleClaim(AssignRoleClaim assignRoleClaim)
        {
            var role = await _roleManager.FindByIdAsync(assignRoleClaim.RoleId);
            Claim claim = new Claim(assignRoleClaim.ClaimType, assignRoleClaim.ClaimValue);
           
            if(role != null)
            {
                var roleClaim =await _roleManager.AddClaimAsync(role, claim);
                if (roleClaim.Succeeded)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> ChangePassword(ChangePasswordRequest changePassword)
        {
            var user = await _userManager.FindByEmailAsync(changePassword.Email);
            if(user != null)
            {
                var isRight = await _userManager.CheckPasswordAsync(user, changePassword.OldPassword);
                if(isRight)
                {
                    await _userManager.ChangePasswordAsync(user,changePassword.OldPassword, changePassword.NewPassword);
                }
                return true;
            }
            return false;
        }

        public async Task<bool> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if( user != null )
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, "123456789Ab!");
                if (result.Succeeded)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRole()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if(roles != null)
            {
                return roles;
            }
            return null;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            if(_userManager.Users != null)
            {
                var users = await _userManager.Users.ToListAsync();
                if(users.Count > 0)
                {
                    return users;
                }
            }
            return null;
        }


        public async Task<LoginResponseDto> Login(LoginRequestDto requestDto)
        {
            var user = await _userManager.FindByNameAsync(requestDto.UserName);
            bool isVaild = await _userManager.CheckPasswordAsync(user, requestDto.Password);
            if(user == null || isVaild == false)
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }
            var roleList = await _userManager.GetRolesAsync(user);
          
            var token = _jwtTokenGenerator.GenerateToken(user, roleList);

            UserDto userDto = new()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };
            LoginResponseDto loginResponseDto = new()
            {
                User = userDto,
                Token = token,
            };
            return loginResponseDto;
        }


        public async Task<string> Register(RegisterationRequestDto requestDto)
        {
            ApplicationUser user = new()
            {
                UserName = requestDto.Email,
                Email = requestDto.Email,
                NormalizedEmail = requestDto.Email.ToUpper(),
                FullName = requestDto.FullName,
                PhoneNumber = requestDto.PhoneNumber
            };
            user.Avt = "asda";
            try
            {
                var accoutInDb = await _userManager.FindByEmailAsync(requestDto.Email);
                if (accoutInDb != null)
                {
                    return $"Tài khoản với email là {requestDto.Email} đã tồi tại";
                }
                else
                {
                    var result = await _userManager.CreateAsync(user, requestDto.Password);

                    if (result.Succeeded)
                    {
                        if (!_roleManager.RoleExistsAsync(Roles.SINHVIEN.ToString()).GetAwaiter().GetResult())
                        {
                          await  _roleManager.CreateAsync(new IdentityRole(Roles.SINHVIEN.ToString()));
                        }
                        await _userManager.AddToRoleAsync(user, Roles.SINHVIEN.ToString());
                        return "";
                    }
                    else
                    {
                        return result.Errors.FirstOrDefault().Description;
                    }
                }
                
            }catch (Exception ex) {
                return ex.Message.ToString();
            }
            
        }
    }
}
