using AutoMapper;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        protected ResponseDto _response;
        public TuitionsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (_context.tuitions == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                var tuitionResult = await _context.tuitions.Include(x => x.tuitionType).ToListAsync();
                if (tuitionResult.Count == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Data is null";
                    return BadRequest(_response);
                }
                IEnumerable<TuitionDto> dto = _mapper.Map<IEnumerable<TuitionDto>>(tuitionResult);
                var result = dto.Select(x => new
                {

                    TuitionId = x.TuitionId,
                    TuitionName = x.TuitionName,
                    TuitionDescription = x.TuitionDescription,
                    Price = x.Price,
                    TuitionTypeId = x.TuitionTypeId,
                    TuitionTypeName = x.tuitionType.TuitionTypename,

                });

                _response.Result = result;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(TuitionDto dto)
        {
            try
            {
                if (_context.tuitions == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                Tuition tuition = _mapper.Map<Tuition>(dto);
                _context.tuitions.Update(tuition);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<TuitionDto>(tuition);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(TuitionDto dto)
        {
            try
            {
                if (_context.tuitions == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                Tuition tuition = _mapper.Map<Tuition>(dto);
                _context.Add(tuition);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<TuitionDto>(tuition);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (_context.tuitions == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                Tuition result = await _context.tuitions.Include(c => c.tuitionType).FirstOrDefaultAsync(t => t.TuitionId == id);
                if (result == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Data is null";
                    return BadRequest(_response);
                }
                var dto = _mapper.Map<TuitionDto>(result);
                _response.Result = new
                {
                    TuitionId = dto.TuitionId,
                    TuitionName = dto.TuitionName,
                    TuitionDescription = dto.TuitionDescription,
                    Price = dto.Price,
                    TuitionTypeId = dto.TuitionTypeId,
                    TuitionTypeName = dto.tuitionType.TuitionTypename,
                };
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_context.tuitions == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                Tuition tuition = await _context.tuitions.FirstOrDefaultAsync(t => t.TuitionId ==  id);
                if(tuition == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Data is null";
                    return BadRequest(_response);
                }
                _context.tuitions.Remove(tuition);
                await _context.SaveChangesAsync();
                _response.Message = "Delete successful";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpGet("GetTuitionInType/{id}")]
        public async Task<IActionResult> GetTuitionInType(int id)
        {
            try
            {
                if (_context.tuitions == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                List<Tuition> tuitions = await _context.tuitions.Where(t => t.TuitionTypeId == id).ToListAsync();
                if(tuitions.Count == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Data is null";
                    return BadRequest(_response);
                }
                _response.Result = _mapper.Map<IEnumerable<TuitionDto>>(tuitions);
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
