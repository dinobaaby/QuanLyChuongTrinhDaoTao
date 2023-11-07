using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _faultyService;
        public FacultyController(IFacultyService faultyService)
        {
            _faultyService = faultyService;
        }

        public async Task<IActionResult> Index()
        {
            List<FacultyDto>? list = new();
            ResponseDto? response = await _faultyService.GetAllFacultyAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<FacultyDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }
    }
}
