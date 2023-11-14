using AutoMapper;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CohortMajorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;
        public CohortMajorsController(ApplicationDbContext context,  IMapper mapper)
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
                if(_context.Cohort_Majors != null)
                {
                    var cohortMajor = await _context.Cohort_Majors.Include(e => e.Major).Include(e => e.Cohort).ToListAsync();
                    if(cohortMajor != null)
                    {
                        var result = _mapper.Map<IEnumerable<Cohort_MajorDto>>(cohortMajor);
                        _response.Result = result.Select(e => new
                        {
                            MajorId = e.MajorId,
                            CohortId = e.CohortId,
                            MajorName = e.Major.MajorName,
                            CohortName = e.Cohort.CohortName
                        });
                        return Ok(_response);
                    }
                    _response.Message = "Data is null";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Message = "Table does not exit";
                _response.IsSuccess = false;
                return BadRequest(_response);

            }catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return NotFound(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cohort_MajorDto cohort_MajorDto)
        {
            try
            {
                if (_context.Cohort_Majors != null)
                {
                    var cohortMajor = _mapper.Map<Cohort_Major>(cohort_MajorDto);
                    
                    await _context.AddAsync(cohortMajor);
                    await  _context.SaveChangesAsync();
                    _response.Result = _mapper.Map<Cohort_MajorDto>(cohortMajor);
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return NotFound(_response);
        }

        [HttpGet("GetCohortInMajor")]
        public async Task<IActionResult> GetCohortInMajor(int majorID)
        {
            try
            {
                if (_context.Cohort_Majors != null)
                {
                    var result = await _context.Cohort_Majors.Include(c => c.Cohort).Include(e => e.Major).Where(e => e.MajorId == majorID).ToListAsync();
                    if(result != null)
                    {
                        var listCohortDto = _mapper.Map<IEnumerable<Cohort_MajorDto>>(result);
                        _response.Result = new  { 
                            MajorName = result.First(e => e.MajorId == majorID).Major.MajorName ,  
                            Cohorts =    listCohortDto.Select(x => 
                            new
                            {
                                CohortId = x.Cohort.CohortId,
                                CohortName = x.Cohort.CohortName
                            })

                        };
                        return Ok(_response);
                    }

                    _response.Message = "Data is null";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Message = "Table does not exit";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return NotFound(_response);
        }

        [HttpGet("GetMajorInCohort")]
        public async Task<IActionResult> GetMajorInCohort(int cohortId)
        {
            try
            {
                if (_context.Cohort_Majors != null)
                {
                    var result = await _context.Cohort_Majors.Include(c => c.Cohort).Include(e => e.Major).Where(e => e.CohortId == cohortId).ToListAsync();
                    if (result != null)
                    {
                        var listCohortDto = _mapper.Map<IEnumerable<Cohort_MajorDto>>(result);
                        _response.Result = new
                        {
                            CohortName = result.First(e => e.CohortId == cohortId).Cohort.CohortName,
                            Majors = listCohortDto.Select(x =>
                            new
                            {
                                MajorId = x.Major.MajorId,
                                MajorName = x.Major.MajorName
                            })

                        };
                        return Ok(_response);
                    }

                    _response.Message = "Data is null";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Message = "Table does not exit";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return NotFound(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cohort_MajorDto cohortMajorDto)
        {
            try
            {
                Cohort_Major value = _mapper.Map<Cohort_Major>(cohortMajorDto);
                _context.Cohort_Majors.Update(value);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<Cohort_MajorDto>(value);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return NotFound(_response);
        }


        [HttpGet("{majorId}/{cohortId}")]
        public async Task<IActionResult> Get(int majorId, int cohortId)
        {
            try
            {
                var result = await _context.Cohort_Majors.Include(c => c.Cohort).Include(c => c.Major).FirstOrDefaultAsync(cm => cm.CohortId == cohortId && cm.MajorId == majorId);
                if(result == null)
                {
                    _response.Message = "Data is null";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                Cohort_MajorDto res = _mapper.Map<Cohort_MajorDto>(result);
                Object obj = new
                {
                    CohortId = res.CohortId,
                    MajorId = res.MajorId,
                    CohortName = res.Cohort.CohortName,
                    MajorName = res.Major.MajorName
                };
                _response.Result = obj;
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return NotFound(_response);
        
        }


        [HttpDelete("{majorId}/{cohortId}")]
        public async Task<IActionResult> Delete(int majorId, int cohortId)
        {
            try
            {
                var result = await _context.Cohort_Majors.FirstOrDefaultAsync(cm => cm.MajorId == majorId && cm.CohortId == cohortId);
                if(result == null)
                {
                    _response.Message = "Data is null";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _context.Cohort_Majors.Remove(result);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<Cohort_MajorDto>(result);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return NotFound(_response);
        }

    }
}