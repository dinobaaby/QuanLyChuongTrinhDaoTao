using ChuongTrinhDaoTao.WebMVC.Services;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTaoDaiHoc.WebMVC.Utilyty;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// add content response web api
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IAuthService, IAuthService>();
SD.ApiBase = builder.Configuration["ServiceUrls:WebApi"];







builder.Services.AddScoped<IAuthService, IAuthService>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.LoginPath = "/";
    options.AccessDeniedPath = "/";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
