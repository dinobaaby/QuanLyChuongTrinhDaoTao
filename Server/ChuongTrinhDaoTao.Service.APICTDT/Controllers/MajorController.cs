using AutoMapper;
using Azure.Core;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected ResponseDto _response;
        private IMapper _mapper;
        public MajorController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMajors()
        {
            try
            {
                var majors = await _context.Major.Include(e => e.Faculty).ToListAsync();
                if (majors == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Không có nghành nào";
                    return BadRequest(_response);
                }
                IEnumerable<object> result = majors.Select(x => new
                {
                    MajorID = x.MajorId,
                    MajorName = x.MajorName,
                    MajorFounding = x.MajorFounding,
                    MajorDescription = x.MajorDescription,
                    FacultyName = x.Faculty.FacultyName,

                });
                _response.Result = result;
                return Ok(_response);
            } catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }
        [HttpGet("MajorInFaculty/{facultyId}")]
        public async Task<IActionResult> MajorInFaculty(string facultyId)
        {
            try
            {
                var majors = await _context.Major.Include(e => e.Faculty).Where(e => e.FacultyId == facultyId).ToListAsync();
                if (majors == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Không có nghành nào";
                    return BadRequest(_response);
                }
                IEnumerable<object> result = majors.Select(x => new
                {
                    MajorID = x.MajorId,
                    MajorName = x.MajorName,
                    MajorFounding = x.MajorFounding,
                    MajorDescription = x.MajorDescription,
                    FacultyName = x.Faculty.FacultyName,

                });
                _response.Result = result;
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
        public async Task<IActionResult> Create(MajorDto majordto)
        {
            try
            {
                var major = _mapper.Map<Major>(majordto);
                await _context.AddAsync(major);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<MajorDto>(major);
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
        public async Task<IActionResult> Update(MajorDto majorDto)
        {
            try
            {
                var major = _mapper.Map<Major>(majorDto);
                _context.Major.Update(major);
                await _context.SaveChangesAsync();
                _response.Result = major;
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
                var major = await _context.Major.FirstOrDefaultAsync(_ => _.MajorId == id);
                if (major == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có major với id là {id}";
                    return BadRequest(_response);
                }
                _context.Major.Remove(major);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<MajorDto>(major);
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
                var major = await _context.Major.Include(f => f.Faculty).FirstOrDefaultAsync(m => m.MajorId == id);
                if (null == major)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có major với id là {id}";
                    return BadRequest(_response);
                }

                var result = _mapper.Map<MajorDto>(major);
                _response.Result = new
                {
                    MajorID = result.MajorId,
                    MajorName = result.MajorName,
                    MajorFounding = result.MajorFounding,
                    MajorDescription = result.MajorDescription,
                    FacultyName = result.Faculty.FacultyName,

                };
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
                    var majorwhenNamenull = await _context.Major.Include(f => f.Faculty).ToListAsync();
                    _response.Result = _mapper.Map<IEnumerable<MajorDto>>(majorwhenNamenull).Select(x => new
                    {
                        MajorID = x.MajorId,
                        MajorName = x.MajorName,
                        MajorFounding = x.MajorFounding,
                        MajorDescription = x.MajorDescription,
                        FacultyName = x.Faculty.FacultyName

                    });
                    return Ok(_response);
                }
                var major = await _context.Major.Include(f => f.Faculty).Where(m => m.MajorName.ToLower().Contains(name.ToLower())).ToListAsync();

                if (null == major)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có major với ten là {name}";
                    return BadRequest(_response);
                }

                _response.Result = _mapper.Map<IEnumerable<MajorDto>>(major).Select(x => new
                {
                    MajorID = x.MajorId,
                    MajorName = x.MajorName,
                    MajorFounding = x.MajorFounding,
                    MajorDescription = x.MajorDescription,
                    FacultyName = x.Faculty.FacultyName

                });
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
