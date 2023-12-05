using ChuongTrinhDaoTao.WebMVC.BussinessModel;
using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class TuitionsController : Controller
    {
        private readonly ITuitionService _tuitionService;
        private readonly ITuitionTypeService _tuitionTypeService;
        public TuitionsController(ITuitionService tuitionService , ITuitionTypeService tuitionTypeService)
        {
            _tuitionService = tuitionService;
            _tuitionTypeService = tuitionTypeService;
        }

        

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ResponseDto response = await _tuitionService.GetAllAsync();
                if (response != null && response.IsSuccess)
                {
                    List<TuitionBM> tuitionTypes = JsonConvert.DeserializeObject<List<TuitionBM>>(Convert.ToString(response.Result));
                    return View(tuitionTypes);
                }
                return BadRequest();
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
                ResponseDto response = await _tuitionTypeService.GetAllAsync();
                if(response != null && response.IsSuccess)
                {
                    List<TuitionTypeDto> tuitionTypeDtos = JsonConvert.DeserializeObject<List<TuitionTypeDto>>(Convert.ToString(response.Result));
                    ViewBag.TuitionTypes = tuitionTypeDtos;
                    return View(new TuitionDto());
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(TuitionDto tuitionDto)
        {
            try
            {
                ResponseDto responsetutionTypes = await _tuitionTypeService.GetAllAsync();
                List<TuitionTypeDto> tuitionTypeDtos = JsonConvert.DeserializeObject<List<TuitionTypeDto>>(Convert.ToString(responsetutionTypes.Result));
                ViewBag.TuitionTypes = tuitionTypeDtos;

                ResponseDto response = await _tuitionService.CreateAsync(tuitionDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Create Tuition Successful";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Tuition Create Error";
                return BadRequest();
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
                ResponseDto response = await _tuitionService.GetAsync(id);
                if (response != null && response.IsSuccess)
                {
                    TuitionBM tuition = JsonConvert.DeserializeObject<TuitionBM>(Convert.ToString(response.Result));
                    return View(tuition);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ResponseDto responsetutionTypes = await _tuitionTypeService.GetAllAsync();
                List<TuitionTypeDto> tuitionTypeDtos = JsonConvert.DeserializeObject<List<TuitionTypeDto>>(Convert.ToString(responsetutionTypes.Result));
                ViewBag.TuitionTypes = tuitionTypeDtos;
                ResponseDto response = await _tuitionService.GetAsync(id);
                if (response != null && response.IsSuccess)
                {
                    TuitionBM tuitionDto = JsonConvert.DeserializeObject<TuitionBM>(Convert.ToString(response.Result));
                    TuitionDto tuition = new TuitionDto
                    {
                        TuitionId = tuitionDto.TuitionId,
                        TuitionName = tuitionDto.TuitionName,
                        TuitionDescription = tuitionDto.TuitionDescription,
                        Price = tuitionDto.Price,
                        TuitionTypeId = tuitionDto.TuitionTypeId,
                    };
                    return View(tuition);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TuitionDto tuition)
        {
            try
            {
                ResponseDto responsetutionTypes = await _tuitionTypeService.GetAllAsync();
                List<TuitionTypeDto> tuitionTypeDtos = JsonConvert.DeserializeObject<List<TuitionTypeDto>>(Convert.ToString(responsetutionTypes.Result));
                ViewBag.TuitionTypes = tuitionTypeDtos;
                ResponseDto response = await _tuitionService.UpdateAsync(tuition);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Edit Tuition Successful";
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
                ResponseDto responsetutionTypes = await _tuitionTypeService.GetAllAsync();
                List<TuitionTypeDto> tuitionTypeDtos = JsonConvert.DeserializeObject<List<TuitionTypeDto>>(Convert.ToString(responsetutionTypes.Result));
                ViewBag.TuitionTypes = tuitionTypeDtos;
                ResponseDto response = await _tuitionService.GetAsync(id);
                if (response != null && response.IsSuccess)
                {
                    TuitionBM tuitionDto = JsonConvert.DeserializeObject<TuitionBM>(Convert.ToString(response.Result));
                    TuitionDto tuition = new TuitionDto
                    {
                        TuitionId = tuitionDto.TuitionId,
                        TuitionName = tuitionDto.TuitionName,
                        TuitionDescription = tuitionDto.TuitionDescription,
                        Price = tuitionDto.Price,
                        TuitionTypeId = tuitionDto.TuitionTypeId,
                    };
                    return View(tuition);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TuitionDto tuition)
        {
            try
            {
                ResponseDto responsetutionTypes = await _tuitionTypeService.GetAllAsync();
                List<TuitionTypeDto> tuitionTypeDtos = JsonConvert.DeserializeObject<List<TuitionTypeDto>>(Convert.ToString(responsetutionTypes.Result));
                ViewBag.TuitionTypes = tuitionTypeDtos;
                ResponseDto response = await _tuitionService.DeleteAsync(tuition.TuitionId);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Delete Tuition Successful";
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
