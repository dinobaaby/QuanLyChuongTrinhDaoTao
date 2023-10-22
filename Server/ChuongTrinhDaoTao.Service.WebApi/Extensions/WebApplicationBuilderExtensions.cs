using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace ChuongTrinhDaoTao.Service.WebApi.Extensions
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
            })
        }
    }
}
