using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChuongTrinhDaoTao.Service.APICTDT.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddAppUthetication(this WebApplicationBuilder builder)
        {
            var secret = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Secret");
            var audience = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Audience");
            var issuer = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Issuer");

            var key= Encoding.ASCII.GetBytes(secret);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true
                };
            });
            return builder;
        }
    }
}
