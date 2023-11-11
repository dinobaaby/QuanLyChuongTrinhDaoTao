using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Services.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChuongTrinhDaoTao.Service.APICTDT.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtOptions.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, applicationUser.FullName),
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName)
            };



            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
