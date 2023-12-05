using ChuongTrinhDaoTao.WebMVC.BussinessModel;
using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class TuitionCTDTController : Controller
    {
        public readonly ITuitionCTDTService _tuitionCTDTService;


        public TuitionCTDTController(ITuitionCTDTService tuitionCTDTService)
        {
            _tuitionCTDTService = tuitionCTDTService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ResponseDto? response = await _tuitionCTDTService.GetAllAsync();
                if(response != null && response.IsSuccess)
                {
                    List<TuitionCTDTBM>? tuitionCTDTs = JsonConvert.DeserializeObject<List<TuitionCTDTBM>>(Convert.ToString(response.Result));
                    return View(tuitionCTDTs);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
