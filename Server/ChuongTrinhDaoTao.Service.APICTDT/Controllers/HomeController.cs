using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected ResponseDto _response;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                int totalFaculty = await _context.Faculties.CountAsync();
                int totalMajor = await _context.Major.CountAsync();
                int totalCohort = await _context.Cohorts.CountAsync();
                int totalBlock = await _context.BlocksOfKnowledge.CountAsync();
                var BlockCourseCounts = await _context.Knowledge_Courses
                                .GroupBy(c => c.BlockOfKnowledgeId)
                                .Select( group => new
                                {
                                    BlockOfKnowledgeId = group.Key,
                                    BlockOfKnowledgeName = _context.BlocksOfKnowledge.First(c => c.BlockOfKnowledgeId == group.Key).BlockOfKnowledgeName,
                                    CourseCount = group.Count()
                                })
                                .ToListAsync();


                _response.Result = new
                {
                    Faculty = totalFaculty,
                    Major = totalMajor,
                    Cohort = totalCohort,
                    Block = totalBlock,
                    BlockCourseCounts = BlockCourseCounts
                };
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }
    }
}
