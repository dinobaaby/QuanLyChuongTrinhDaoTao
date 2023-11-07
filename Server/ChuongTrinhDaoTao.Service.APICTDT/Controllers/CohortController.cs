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
    public class CohortController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected ResponseDto _response;
        private IMapper _mapper;
        public CohortController(ApplicationDbContext context,  IMapper mapper)
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
                var cohorts = await _context.Cohorts.ToListAsync();
                if( cohorts == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table Cohort is not found";
                    return NotFound(_response);
                }
               
                _response.Result = _mapper.Map<IEnumerable<CohortDto>>(cohorts);
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CohortDto cohortDto)
        {
            try
            {
                Cohort cohort = _mapper.Map<Cohort>(cohortDto);
                await  _context.AddAsync(cohort);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<CohortDto>(cohort);
                return Ok(_response);
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CohortDto cohortDto)
        {
            try
            {
                var cohort = _mapper.Map<Cohort>(cohortDto);
                _context.Cohorts.Update(cohort);
                await _context.SaveChangesAsync();
                _response.Result = cohort;
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
                var cohort = await _context.Cohorts.FirstOrDefaultAsync(_ => _.CohortId == id);
                if (cohort == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có major với id là {id}";
                    return BadRequest(_response);
                }
                _context.Cohorts.Remove(cohort);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<CohortDto>(cohort);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpPost("CohortWithMajor")]
        public async Task<IActionResult> CohortWithMajor(CohortDto dto)
        {
            try
            {
                Cohort result = _mapper.Map<Cohort>(dto);
                await _context.Cohorts.AddAsync(result);
                await _context.SaveChangesAsync();
                foreach (int majorId in result.MajorIds)
                {
                    var Cm = new Cohort_Major { MajorId = majorId, CohortId = result.CohortId};
                    await _context.Cohort_Majors.AddAsync(Cm);
                }
                await _context.SaveChangesAsync();

                var rResult = _mapper.Map<CohortDto>(result);
                _response.Result = new CohortDto
                {
                    CohortId = rResult.CohortId,
                    CohortName = rResult.CohortName,
                    CohortDescription = rResult.CohortDescription,
                    StartDay = rResult.StartDay,
                    EndDay = rResult.EndDay,
                    MajorIds = rResult.MajorIds,
                };
                return Ok(_response);
            }catch (Exception ex)
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
                var cohosts = await _context.Cohorts.FirstOrDefaultAsync(m => m.CohortId == id);
                if (null == cohosts)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có cohosts với id là {id}";
                    return BadRequest(_response);
                }

                
                _response.Result = _mapper.Map<CohortDto>(cohosts);
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
                    var cohortwhenNamenull = await _context.Cohorts.ToListAsync();
                    _response.Result = _mapper.Map<IEnumerable<CohortDto>>(cohortwhenNamenull);
                    return Ok(_response);
                }
                var cohorts = await _context.Cohorts.Where(m => m.CohortName.ToLower().Contains(name.ToLower())).ToListAsync();

                if (null == cohorts)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Không có cohorts với ten là {name}";
                    return BadRequest(_response);
                }

                _response.Result = _mapper.Map<IEnumerable<CohortDto>>(cohorts);
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
