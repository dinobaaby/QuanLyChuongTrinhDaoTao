using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class TuitionTypesController : Controller
    {
        public readonly ITuitionTypeService _tuitionTypeService;
        public TuitionTypesController(ITuitionTypeService tuitionTypeService)
        {
            _tuitionTypeService = tuitionTypeService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ResponseDto response = await _tuitionTypeService.GetAllAsync();
                if(response != null && response.IsSuccess)
                {
                    List<TuitionTypeDto> tuitionTypes = JsonConvert.DeserializeObject<List<TuitionTypeDto>>(Convert.ToString(response.Result));
                    return View(tuitionTypes);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View(new TuitionTypeDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create(TuitionTypeDto tuitionTypeDto)
        {
            try
            {
                ResponseDto response =await _tuitionTypeService.CreateAsync(tuitionTypeDto);
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Create TuitionType Successful";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "TuitionTypes Create Error";
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
                ResponseDto response = await _tuitionTypeService.GetAsync(id);
                if( response != null && response.IsSuccess)
                {
                    TuitionTypeDto tuitionType = JsonConvert.DeserializeObject<TuitionTypeDto>(Convert.ToString(response.Result));
                    return View(tuitionType);
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
                ResponseDto response = await _tuitionTypeService.GetAsync(id);
                if (response != null && response.IsSuccess)
                {
                    TuitionTypeDto tuitionType = JsonConvert.DeserializeObject<TuitionTypeDto>(Convert.ToString(response.Result));
                    return View(tuitionType);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TuitionTypeDto tuitionType)
        {
            try
            {
                ResponseDto response = await _tuitionTypeService.UpdateAsync(tuitionType);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Edit TuitionType Successful";
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
                ResponseDto response = await _tuitionTypeService.GetAsync(id);
                if (response != null && response.IsSuccess)
                {
                    TuitionTypeDto tuitionType = JsonConvert.DeserializeObject<TuitionTypeDto>(Convert.ToString(response.Result));
                    return View(tuitionType);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TuitionTypeDto tuitionTypeDto)
        {
            try
            {
                ResponseDto response = await _tuitionTypeService.DeleteAsync(tuitionTypeDto.TuitionTypeId);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Delete TuitionType Successful";
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
