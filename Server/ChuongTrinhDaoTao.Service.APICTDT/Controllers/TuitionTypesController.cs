using AutoMapper;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        protected ResponseDto _response;
        public TuitionTypesController(ApplicationDbContext context, IMapper mapper)
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
                if (_context.tuitionTypes == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }

                var tuitiontypes = await _context.tuitionTypes.ToListAsync();
                if (tuitiontypes != null)
                {
                    IEnumerable<TuitionTypeDto> result = _mapper.Map<IEnumerable<TuitionTypeDto>>(tuitiontypes);
                    _response.Result = result.Select(c => new
                    {
                        TuitionTypeId = c.TuitionTypeId,
                        TuitionTypename = c.TuitionTypename
                    });
                    return Ok(_response);
                }
                _response.IsSuccess = false;
                _response.Message = "Data null";
                return BadRequest(_response);
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
                if (_context.tuitionTypes == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }

                var tuitiontypes = await _context.tuitionTypes.FirstOrDefaultAsync(t => t.TuitionTypeId == id);
                if (tuitiontypes != null)
                {
                    
                    _response.Result =  new
                    {
                        TuitionTypeId = tuitiontypes.TuitionTypeId,
                        TuitionTypename = tuitiontypes.TuitionTypename
                    };
                    return Ok(_response);
                }
                _response.IsSuccess = false;
                _response.Message = "Data null";
                return BadRequest(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(TuitionTypeDto dto)
        {
            try
            {
                if (_context.tuitionTypes == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                TuitionType resultCreate = _mapper.Map<TuitionType>(dto);
                _context.tuitionTypes.Add(resultCreate);
                await _context.SaveChangesAsync();
                _response.Result = dto;
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
                if (_context.tuitionTypes == null && id == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit or id equas 0";
                    return BadRequest(_response);
                }
                var tuitionTypes = await _context.tuitionTypes.FirstOrDefaultAsync(c => c.TuitionTypeId == id);
                if (tuitionTypes == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Tuition not found";
                    return BadRequest(_response);
                }
                _context.tuitionTypes.Remove(tuitionTypes);
                await _context.SaveChangesAsync();
                _response.Message = "Delete is successful";
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
        public async Task<IActionResult> Update(TuitionTypeDto tuitionTypeDto)
        {
            try
            {
                if (_context.tuitionTypes == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit or id equas 0";
                    return BadRequest(_response);
                }
                TuitionType tuitionType = _mapper.Map<TuitionType>(tuitionTypeDto);
                _context.tuitionTypes.Update(tuitionType);
                await _context.SaveChangesAsync();

                _response.Result = tuitionType;
                _response.Message = "Update successful";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }
    }
}
