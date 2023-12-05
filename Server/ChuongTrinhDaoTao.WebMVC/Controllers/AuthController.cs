using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Reflection;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequest = new();
            return View(loginRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto login)
        {
            try
            {
                ResponseDto response = await _authService.LoginAsync(login);
                if(response != null && response.IsSuccess)
                {
                    LoginResponseDto responseLogin = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));
                    await SignInAsync(responseLogin);
                    _tokenProvider.SetToken(responseLogin.Token);
                    return RedirectToAction("Admin", "Home");
                }
                return View(login);
            }
            catch
            {
                return View(login);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterationRequestDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDto registerationRequest)
        {
            try
            {
                ResponseDto response = await _authService.RegisterAsync(registerationRequest);
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Create acount Successful";
                    return RedirectToAction("Login");
                }
                TempData["error"] = "Create acount failed";
                return View(registerationRequest);
            }catch  (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private async Task SignInAsync(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model.Token);
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));
            identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }






    }
}
