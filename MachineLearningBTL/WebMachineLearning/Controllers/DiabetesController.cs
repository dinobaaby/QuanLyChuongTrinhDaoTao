using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMachineLearning.Models;
using WebMachineLearning.Services.IService;
namespace WebMachineLearning.Controllers
{
    public class DiabetesController : Controller
    {
        private readonly IDiebetesService _diebetesService;
        public DiabetesController(IDiebetesService diebetesService)
        {
            _diebetesService = diebetesService;
        }

        [HttpGet]
        public IActionResult CheckResult()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CheckResult(DiaBetes dto)
        {
            try
            {
                ResponseDto? reponse = await _diebetesService.TestData(dto);
                if(reponse != null && reponse.IsSuccess)
                {
                    Result result = JsonConvert.DeserializeObject<Result>(Convert.ToString(reponse.Result));
                    return RedirectToAction("Index", result);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Index(Result result)
        {
            return View(result);
        }


    }
}
