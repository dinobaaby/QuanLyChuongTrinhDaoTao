using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ResponseDto? response = await _courseService.GetAllAsync();
                if(response != null && response.IsSuccess) 
                {
                    List<CourseDto>? list = JsonConvert.DeserializeObject<List<CourseDto>>(Convert.ToString(response.Result));
                    return View(list);
                }
                return BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                ResponseDto? response = await _courseService.GetByNameAsync(name);
                if(response != null && response.IsSuccess)
                {
                    List<CourseDto>? list = JsonConvert.DeserializeObject<List<CourseDto>>(Convert.ToString(response.Result));
                    return View(list);
                }
                return BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                ResponseDto? response = await _courseService.GetByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    CourseDto result = JsonConvert.DeserializeObject<CourseDto>(Convert.ToString(response.Result));
                    return View(result);
                }
                return BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CourseDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create(CourseDto dto)
        {
            try
            {
                ResponseDto? response = await _courseService.CreateAsync(dto);
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Create Course successful";
                    return RedirectToAction("Index");
                }
                return BadRequest();
            }catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ResponseDto? response = await _courseService.GetByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    CourseDto result = JsonConvert.DeserializeObject<CourseDto>(Convert.ToString(response.Result));
                    return View(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseDto dto)
        {
            try
            {
                ResponseDto? response = await _courseService.UpdateAsync(dto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Update Course successful";
                    return RedirectToAction("Index");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                ResponseDto? response = await _courseService.GetByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    CourseDto result = JsonConvert.DeserializeObject<CourseDto>(Convert.ToString(response.Result));
                    return View(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CourseDto dto)
        {
            try
            {
                ResponseDto? response = await _courseService.DeleteAsync(dto.CourseId);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Delete course successful";
                    return RedirectToAction("Index");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
