
using WebMachineLearning.Services.IService;
using WebMachineLearning.Services;
using WebMachineLearning.Utilyty;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IDiebetesService, DiabetesService>();
SD.ApiBase = builder.Configuration["ServiceUrls:WebApi"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IDiebetesService, DiabetesService>();
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
