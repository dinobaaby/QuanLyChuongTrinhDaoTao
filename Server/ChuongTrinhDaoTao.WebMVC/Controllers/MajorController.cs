using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class MajorController : Controller
    {
        private readonly IMajorService _majorService;
        private readonly IFacultyService _faultyService;
        public MajorController(IMajorService majorService, IFacultyService facultyService)
        {
            _majorService = majorService;
            _faultyService = facultyService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<MajorDto> listMajor = new();
                ResponseDto? response = await _majorService.GetAllMajorAsync();
                if(response != null && response.IsSuccess)
                {
                    listMajor = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response.Result));
                    return View(listMajor);
                }
                return NotFound();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<FacultyDto>? list = new();
            ResponseDto? responseFaculty = await _faultyService.GetAllFacultyAsync();

            list = JsonConvert.DeserializeObject<List<FacultyDto>>(Convert.ToString(responseFaculty.Result));

            ViewBag.Facultys = list;
            return View(new MajorDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create(MajorDto majorDto)
        {
            try
            {
                List<FacultyDto>? list = new();
                ResponseDto? responseFaculty = await _faultyService.GetAllFacultyAsync();

                list = JsonConvert.DeserializeObject<List<FacultyDto>>(Convert.ToString(responseFaculty.Result));

                ViewBag.Facultys = list;

                ResponseDto? response = await _majorService.CreateMajorAsync(majorDto);
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Faculty create successfull";
                    return RedirectToAction("Index");
                }
                return NotFound();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                ResponseDto response = await _majorService.GetMajorByIdAsync(id);
                if(response != null && response.IsSuccess)
                {
                    MajorDto major = JsonConvert.DeserializeObject<MajorDto>(Convert.ToString(response.Result));
                    return View(major);
                }
                return NotFound();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                List<FacultyDto>? list = new();
                ResponseDto? responseFaculty = await _faultyService.GetAllFacultyAsync();
                list = JsonConvert.DeserializeObject<List<FacultyDto>>(Convert.ToString(responseFaculty.Result));
                ViewBag.Facultys = list;
                ResponseDto response = await _majorService.GetMajorByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    MajorDto major = JsonConvert.DeserializeObject<MajorDto>(Convert.ToString(response.Result));
                    return View(major);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMajor(int id)
        {
            try
            {
                List<FacultyDto>? list = new();
                ResponseDto? responseFaculty = await _faultyService.GetAllFacultyAsync();
                list = JsonConvert.DeserializeObject<List<FacultyDto>>(Convert.ToString(responseFaculty.Result));
                ViewBag.Facultys = list;
                ResponseDto response = await _majorService.DeleteMajorAsync(id);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Faculty delete successfull";
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            try
            {
                List<FacultyDto>? list = new();
                ResponseDto? responseFaculty = await _faultyService.GetAllFacultyAsync();
                list = JsonConvert.DeserializeObject<List<FacultyDto>>(Convert.ToString(responseFaculty.Result));
                ViewBag.Facultys = list;

                ResponseDto response = await _majorService.GetMajorByIdAsync(id);
                if (response != null && response.IsSuccess)
                {
                    MajorDto major = JsonConvert.DeserializeObject<MajorDto>(Convert.ToString(response.Result));
                    return View(major);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(MajorDto majorDto)
        {
            try
            {
                List<FacultyDto>? list = new();
                ResponseDto? responseFaculty = await _faultyService.GetAllFacultyAsync();
                list = JsonConvert.DeserializeObject<List<FacultyDto>>(Convert.ToString(responseFaculty.Result));
                ViewBag.Facultys = list;

                ResponseDto response = await _majorService.UpdateMajorAsync(majorDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Faculty Update successfull";
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> MajorInFaculty(string id)
        {
            try
            {
                List<MajorDto>? list = new();
                ResponseDto response = await _majorService.GetMajorInFacultyAsync(id);
                if(response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response.Result));
                    TempData["success"] = $"Majors in Faculty with ID: {id}";
                    return View(list);
                }
                TempData["Error"] = "Error";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
