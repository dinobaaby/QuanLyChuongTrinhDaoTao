using ChuongTrinhDaoTao.Service.WebApi.Models.Dto;
using ChuongTrinhDaoTao.Service.WebApi.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuongTrinhDaoTao.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDto();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDto requestDto)
        {
            var errorMessage = await _authService.Register(requestDto);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(string email, string rolename)
        {
            var isSuccess = await _authService.AssignRole(email, rolename);
            if(!isSuccess)
            {
                _response.IsSuccess = false;
             
                _response.Message = "Error";
                return BadRequest(_response);
            }
            _response.Message = "Success";
            return Ok(_response);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await _authService.GetAllUsers();
                if(users == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Error";
                    return BadRequest(_response);
                }
                var userEmail = users.Select(u => new
                {
                    Email = u.Email
                });
                _response.Result = userEmail;
                return Ok(_response);
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePassword)
        {
            try
            {
                var isChangeSuccess = await _authService.ChangePassword(changePassword);
                if (!isChangeSuccess)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Thay đổi mật khẩu không thành công";
                    return BadRequest(_response);
                }
                _response.Message = "Thay đồi mật khẩu thành công";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                var isSuccess = await _authService.ForgotPassword(email);
                if (!isSuccess)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Cập nhật thất bại";
                    return BadRequest(_response);
                }
                _response.Message = "Cập nhật thành công password mới đã được gửi vào email của bạn";
                return Ok(_response);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            } 
        }


        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _authService.GetAllRole();
                if(roles == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Chưa có role nào";
                    return BadRequest(_response);
                }
               // var roleName = roles.Select(x => x.Name);
                _response.Result = roles;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("AssignRoleClaim")]
        public async Task<IActionResult> AssignRoleClaim(AssignRoleClaim assignRoleClaim)
        {
            try
            {
                var isAssignRoleClaim = await _authService.AssignRoleClaim(assignRoleClaim);
                if (!isAssignRoleClaim)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Không thể thêm claim cho role";
                    return BadRequest(_response);
                }
                _response.Message = $"Đã thêm claim type là {assignRoleClaim.ClaimType} với giá trì claim value là {assignRoleClaim.ClaimValue} cho role : {assignRoleClaim.RoleId}";
                return Ok(_response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
