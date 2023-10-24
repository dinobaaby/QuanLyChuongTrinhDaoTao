using AutoMapper;
using ChuongTrinhDaoTao.Service.API.Data;

using ChuongTrinhDaoTao.Service.API.Models;
using ChuongTrinhDaoTao.Service.API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuongTrinhDaoTao.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected ResponseDto _response;
        private IMapper _mapper;
        public FacultiesController(ApplicationDbContext context,  IMapper mapper)
        {
            _context = context;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(_context.Faculties != null)
            {
               
                IEnumerable<Faculty> objList = await _context.Faculties.Include(m => m.Majors).ToListAsync();
                objList = objList.Select(a => new Faculty
                {
                    FacultyId = a.FacultyId,
                    FacultyDescription = a.FacultyDescription,
                    FacultyName = a.FacultyName,
                    MajorCount = a.Majors.Count(),
                });

                if (objList != null)
                {
                    _response.Result = _mapper.Map<IEnumerable<FacultyDto>>(objList);
                    return Ok(_response);
                }
                _response.Message = "Bảng khoa không có giá trị nào cả!";
                return BadRequest(_response);
            }
            _response.Message = "Khong có bảng khoa";
            return NotFound(_response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.FacultyId == id);
                if(faculty == null)
                {
                    _response.Message = "Không tìm thấy";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Result = _mapper.Map<FacultyDto>(faculty);
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.IsSuccess=false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(FacultyDto model)
        {
            try
            {
                Faculty faculy = _mapper.Map<Faculty>(model);

                await _context.AddAsync(faculy);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<FacultyDto>(faculy);
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
               
            }
            return BadRequest(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FacultyDto model)
        {
            try
            {
                Faculty faculty = _mapper.Map<Faculty>(model);
                _context.Faculties.Update(faculty);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<FacultyDto>(faculty);
                return Ok(_response);
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return BadRequest(_response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.FacultyId == id);
                if(faculty == null)
                {
                    _response.Message = $"Không tìm thấy tên khoa với mã khoa là {id}";
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _context.Faculties.Remove(faculty);
                await _context.SaveChangesAsync();
                _response.Message = "Delete successful";
                return Ok(_response);

            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return BadRequest(_response);
        }

    }
}
