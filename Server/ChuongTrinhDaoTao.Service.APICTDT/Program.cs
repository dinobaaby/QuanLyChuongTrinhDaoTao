
using AutoMapper;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Extensions;
using ChuongTrinhDaoTao.Service.APICTDT.Helpers;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Services;
using ChuongTrinhDaoTao.Service.APICTDT.Services.IService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Mapping
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add database
builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DbDefault")));


// Config Jwt options
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));



// Add Table identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();







// Cấu hình khởi tạo
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRateLimiter(o => o.AddFixedWindowLimiter(policyName: "ratepolicy", options =>
{
    options.QueueLimit = 0;
    options.PermitLimit = 1;
    options.Window = TimeSpan.FromSeconds(1);
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}).RejectionStatusCode = 401);



builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{}
        }
    });
});




builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
});


builder.AddAppUthetication();
builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseRateLimiter();
app.UseAuthorization();

app.MapControllers();

app.Run();
