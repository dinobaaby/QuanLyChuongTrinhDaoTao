using AutoMapper;
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
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected ResponseDto _response;
        private IMapper _mapper;
        public CoursesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _context.Courses.ToListAsync();
                if (courses == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table Cohort is not found";
                    return NotFound(_response);
                }
                IEnumerable<CourseDto> listCourseDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
                
                _response.Result = listCourseDto;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseDto courseDto)
        {
            try
            {
                Course course = _mapper.Map<Course>(courseDto);

                await _context.AddAsync(course);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<CourseDto>(course);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseDto CourseDto)
        {
            try
            {
                var course = _mapper.Map<Course>(CourseDto);
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                _response.Result = course;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(_ => _.CourseId == id);
                if (course == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có major với id là {id}";
                    return BadRequest(_response);
                }
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<CourseDto>(course);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseId == id);
                if (null == course)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có cohosts với id là {id}";
                    return BadRequest(_response);
                }

              
                _response.Result = _mapper.Map<CourseDto>(course);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string? name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    var cohortwhenNamenull = await _context.Courses.ToListAsync();
                    _response.Result = _mapper.Map<IEnumerable<CourseDto>>(cohortwhenNamenull);
                    return Ok(_response);
                }
                var Courses = await _context.Courses.Where(m => m.CourseName.ToLower().Contains(name.ToLower())).ToListAsync();

                if (null == Courses)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có Courses với ten là {name}";
                    return BadRequest(_response);
                }

                _response.Result = _mapper.Map<IEnumerable<CourseDto>>(Courses);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }
    }
}
