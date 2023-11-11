using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacultyDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _faultyService.CreateFacultyAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Faculty create successfull";

                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                ResponseDto? result = await _faultyService.GetFacultyByIdAsync(id);
                if (result != null && result.IsSuccess)
                {
                    FacultyDto model = JsonConvert.DeserializeObject<FacultyDto>(Convert.ToString(result.Result));
                    return View(model);
                }
                return NotFound();

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFaculty(string id)
        {
            ResponseDto? response = await _faultyService.DeleteFacultyAsync(id);
            
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Faculty delete successfull";
              
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, response.Message);
            return RedirectToAction("Delete", id);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                ResponseDto? result = await _faultyService.GetFacultyByIdAsync(id);
                if (result != null && result.IsSuccess)
                {

                    FacultyDto model = JsonConvert.DeserializeObject<FacultyDto>(Convert.ToString(result.Result));
                    return View(model);
                }
                return NotFound();

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(FacultyDto faculty)
        {
            try
            {
                ResponseDto? response = await _faultyService.UpdateFacultyAsync(faculty);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = $"Faculty with id = {faculty.FacultyId} edit successfull ";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, response.Message);
                return View(faculty);
            }catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
