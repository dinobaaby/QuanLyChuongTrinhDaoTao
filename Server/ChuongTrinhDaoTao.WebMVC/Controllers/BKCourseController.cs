using ChuongTrinhDaoTao.WebMVC.BussinessModel;
using ChuongTrinhDaoTao.WebMVC.Model;
using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace ChuongTrinhDaoTao.WebMVC.Controllers
{
    public class BKCourseController : Controller
    {
        private readonly IBlockOfKnowledgeCourseService _blockOfKnowledgeCourse;
        private readonly IMajorService _majorService;
        private readonly ICohortService _cohortService;
        private readonly ICourseService _courseService;
        private readonly IBlockOfKnowledgeService _blockOfKnowledgeService;

        public BKCourseController(IBlockOfKnowledgeCourseService blockOfKnowledgeCourse, IMajorService majorService, ICohortService cohortService, ICourseService courseService, IBlockOfKnowledgeService blockOfKnowledgeService)
        {
            _blockOfKnowledgeCourse = blockOfKnowledgeCourse;
            _majorService = majorService;
            _cohortService = cohortService;
            _courseService = courseService;
            _blockOfKnowledgeService = blockOfKnowledgeService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ResponseDto? response = await _blockOfKnowledgeCourse.GetAllAsync();
                if(response != null && response.IsSuccess)
                {
                    List<BlockOfKnowledge_CourseBM>? list = JsonConvert.DeserializeObject<List<BlockOfKnowledge_CourseBM>>(Convert.ToString(response.Result));
                    return View(list);
                }
                TempData["error"] = "Null";
                return BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> ChuongTrinhDaoTao(int majorId, int cohortId)
        {
            try
            {
                ResponseDto? course = await _courseService.GetAllAsync();
                ResponseDto? block = await _blockOfKnowledgeService.GetAllAsync();
                ViewBag.Courses = JsonConvert.DeserializeObject<List<CourseDto>>(Convert.ToString(course.Result));
                ViewBag.Blocks = JsonConvert.DeserializeObject<List<BlockOfKnowledgeDto>>(Convert.ToString(block.Result));
                ResponseDto? response = await _blockOfKnowledgeCourse.ChiTietChuongTrinhDaiHocAsync(majorId, cohortId);
                if(response != null && response.IsSuccess)
                {
                    ChuongTrinhDaoTaoBM? item = JsonConvert.DeserializeObject<ChuongTrinhDaoTaoBM>(Convert.ToString(response.Result));
                    return View(item);
                }
                TempData["error"] = "Error";
                return BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                ResponseDto? majors = await _majorService.GetAllMajorAsync();
                ResponseDto? cohorts = await _cohortService.GetAllAsync();
                ResponseDto? course = await _courseService.GetAllAsync();
                ResponseDto? blcok = await _blockOfKnowledgeService.GetAllAsync();
                ViewBag.Majors = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(majors.Result));
                ViewBag.Cohorts = JsonConvert.DeserializeObject<List<CohortDto>>(Convert.ToString(cohorts.Result));
                ViewBag.Courses = JsonConvert.DeserializeObject<List<CourseDto>>(Convert.ToString(course.Result));
                ViewBag.Blocks = JsonConvert.DeserializeObject<List<BlockOfKnowledgeDto>>(Convert.ToString(blcok.Result));

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlockOfKnowledge_Course block)
        {
            try
            {
                ResponseDto? majors = await _majorService.GetAllMajorAsync();
                ResponseDto? cohorts = await _cohortService.GetAllAsync();
                ResponseDto? course = await _courseService.GetAllAsync();
                ResponseDto? blcok = await _blockOfKnowledgeService.GetAllAsync();
                ViewBag.Majors = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(majors.Result));
                ViewBag.Cohorts = JsonConvert.DeserializeObject<List<CohortDto>>(Convert.ToString(cohorts.Result));
                ViewBag.Courses = JsonConvert.DeserializeObject<List<CourseDto>>(Convert.ToString(course.Result));
                ViewBag.Blocks = JsonConvert.DeserializeObject<List<BlockOfKnowledgeDto>>(Convert.ToString(blcok.Result));


                ResponseDto? response = await _blockOfKnowledgeCourse.CreateAsync(block);
                if(response != null && response.IsSuccess)
                {
                    TempData["success"] = "Create BKCourse successful";
                    return RedirectToAction("ChuongTrinhDaoTao", new {majorId = block.MajorId, cohortId = block.CohortId});
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
