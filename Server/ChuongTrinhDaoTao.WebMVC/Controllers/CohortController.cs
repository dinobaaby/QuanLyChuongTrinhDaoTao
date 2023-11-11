using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class CohortController : Controller
    {
        private readonly ICohortService _cohortService;
        private readonly IMajorService _majorService;
        public CohortController(ICohortService cohortService, IMajorService majorService)
        {
            _cohortService = cohortService;
            _majorService = majorService;
        }

        public async  Task<IActionResult> Index()
        {
            try
            {
                List<CohortDto> list = new();
                ResponseDto response = await _cohortService.GetAllAsync();
                if(response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<CohortDto>>(Convert.ToString(response.Result));
                    return View(list);
                }
                return View(null);
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {

                ResponseDto response = await _majorService.GetAllMajorAsync();
                if(response != null && response.IsSuccess)
                {
                    List<MajorDto> majorDtos = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response.Result));
                    ViewBag.Majors = majorDtos;
                    return View();
                }
                return NotFound();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CohortDto dto)
        {
            try
            {

                ResponseDto response1 = await _majorService.GetAllMajorAsync();
                List<MajorDto> majorDtos = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response1.Result));
                ViewBag.Majors = majorDtos;
                ResponseDto response = await _cohortService.CreatesAsync(dto);
                if (response != null && response.IsSuccess)
                {
                  
                    return RedirectToAction("Index");
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                ResponseDto response1 = await _majorService.GetAllMajorAsync();
                ResponseDto response = await _cohortService.GetByIdAsync(id);
                if(response != null && response.IsSuccess)
                {
                    List<MajorDto> majorDtos = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response1.Result));
                    ViewBag.Majors = majorDtos;
                    CohortDto cohort = JsonConvert.DeserializeObject<CohortDto>(Convert.ToString(response.Result));
                    return View(cohort);
                }
                return NotFound();  
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
                ResponseDto response1 = await _majorService.GetAllMajorAsync();
                List<MajorDto> majorDtos = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response1.Result));
                ViewBag.Majors = majorDtos;
                ResponseDto response = await _cohortService.GetByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                   
                    CohortDto cohort = JsonConvert.DeserializeObject<CohortDto>(Convert.ToString(response.Result));
                    return View(cohort);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CohortDto cohort)
        {
            try
            {
                ResponseDto response1 = await _majorService.GetAllMajorAsync();
                ResponseDto response = await _cohortService.UpdateAsync(cohort);
                if (response != null && response.IsSuccess)
                {
                    List<MajorDto> majorDtos = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response1.Result));
                    ViewBag.Majors = majorDtos;
                    TempData["success"] = "Updete cohort successful";
                    return RedirectToAction("Index");
                }
                return NotFound();
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
                ResponseDto response = await _cohortService.GetByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    CohortDto cohort = JsonConvert.DeserializeObject<CohortDto>(Convert.ToString(response.Result));
                    return View(cohort);
                }
                return NotFound();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CohortDto cohort)
        {
            try
            {
                ResponseDto response = await _cohortService.DeleteAsync(cohort.CohortId);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Delete cohort Successful";
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
