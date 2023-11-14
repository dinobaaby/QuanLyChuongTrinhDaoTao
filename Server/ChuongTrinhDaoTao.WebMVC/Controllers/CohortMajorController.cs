using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class CohortMajorController : Controller
    {
        private readonly ICohortMajorService _cohortMajorService;
        private readonly IMajorService _majorService;
        private readonly ICohortService _cohortService;

        public CohortMajorController(ICohortMajorService cohortMajorService, IMajorService majorService, ICohortService cohortService)
        {
            _cohortMajorService = cohortMajorService;
            _majorService = majorService;
            _cohortService = cohortService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ResponseDto response = await _cohortMajorService.GetAllAsync();
                if(response != null && response.IsSuccess)
                {
                    List<Cohort_MajorDto> list = JsonConvert.DeserializeObject<List<Cohort_MajorDto>>(Convert.ToString(response.Result));
                    return View(list);
                }
                else
                {
                    TempData["error"] = "Truy van du lieu that bai";
                    return BadRequest();
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                ResponseDto majorList = await _majorService.GetAllMajorAsync();
                ResponseDto cohortList = await _cohortService.GetAllAsync();
                List<MajorDto> majors = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(majorList.Result));
                List<CohortDto> cohorts = JsonConvert.DeserializeObject<List<CohortDto>>(Convert.ToString(cohortList.Result));
                ViewBag.MajorList = majors;
                ViewBag.CohortList = cohorts;
                return View(new Cohort_MajorDto());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int majorId, int cohortId)
        {
            try
            {
                ResponseDto response = await _cohortMajorService.GetCohortMajorByIdAsync(majorId, cohortId);
                if(response != null && response.IsSuccess)
                {
                    Cohort_MajorDto result = JsonConvert.DeserializeObject<Cohort_MajorDto>(Convert.ToString(response.Result));
                    return View(result);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cohort_MajorDto dto)
        {
            try
            {
                ResponseDto majorList = await _majorService.GetAllMajorAsync();
                ResponseDto cohortList = await _cohortService.GetAllAsync();
                ResponseDto response = await _cohortMajorService.CreateAsync(dto);
                List<MajorDto> majors = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(majorList.Result));
                List<CohortDto> cohorts = JsonConvert.DeserializeObject<List<CohortDto>>(Convert.ToString(cohortList.Result));
                ViewBag.MajorList = majors;
                ViewBag.CohortList = cohorts;
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Create successful";
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
        public async Task<IActionResult> Delete(int majorId, int cohortId)
        {
            try
            {
                ResponseDto response = await _cohortMajorService.GetCohortMajorByIdAsync(majorId, cohortId);
                if(response != null && response.IsSuccess)
                {
                    Cohort_MajorDto result = JsonConvert.DeserializeObject<Cohort_MajorDto>(Convert.ToString(response.Result));
                    return View(result);
                }
                return BadRequest();
            }catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cohort_MajorDto dto)
        {
            try
            {
                ResponseDto response = await _cohortMajorService.DeleteAsync(dto.MajorId, dto.CohortId);
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Delete Successful";
                    return RedirectToAction("Index");    
                }
                TempData["error"] = "Error";
                return View(dto);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
