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
    public class BlockOfKnowledgeCoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;
        public BlockOfKnowledgeCoursesController(ApplicationDbContext context, IMapper mapper)
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
                if (_context.Knowledge_Courses != null)
                {
                    var value = await _context.Knowledge_Courses.Include(e => e.BlockOfKnowledge).Include(e => e.Course).Include(e => e.Cohort_Major).ThenInclude(e => e.Cohort).Include(e => e.Cohort_Major)
                        .ThenInclude(e => e.Major).ToListAsync();
                    if (value != null)
                    {
                        var result = _mapper.Map<IEnumerable<BlockOfKnowledge_CourseDto>>(value);
                        _response.Result = result.Select(e => new
                        {
                            BlockOfKnowledgeId = e.BlockOfKnowledgeId,
                            CourseId = e.CourseId,
                            MajorId = e.MajorId,
                            CohortId = e.CohortId,
                            BlockOfKnowledgeName = e.BlockOfKnowledge.BlockOfKnowledgeName,
                            CourseName = e.Course.CourseName,
                            MajorName = e.Cohort_Major.Major.MajorName,
                            CohortName = e.Cohort_Major.Cohort.CohortName

                        }); ;
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

        [HttpGet("CourseInBlockCourse/{blockCourseId}")]
        public async Task<IActionResult> CourseInBlockCourse(int blockCourseId)
        {
            try
            {
                if(_context.BlocksOfKnowledge != null)
                {
                    var courses = await _context.Knowledge_Courses.Include(b => b.BlockOfKnowledge).Include(c => c.Course).Where(bl => bl.BlockOfKnowledgeId == blockCourseId).ToListAsync();
                    if(courses != null)
                    {
                        IEnumerable<BlockOfKnowledge_CourseDto> courseDto = _mapper.Map<IEnumerable<BlockOfKnowledge_CourseDto>>(courses);
                        _response.Result = new
                        {
                            BlockOfKnowledgeName = courseDto.First().BlockOfKnowledge.BlockOfKnowledgeName,
                            Courses = courseDto.Select(c => new
                            {
                                CourseId = c.CourseId,
                                CourseName = c.Course.CourseName
                            }).Distinct().ToList()
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
            catch(Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
        }

        [HttpGet("ChiTietChuongtrinhDaoTao/{majorId}/{cohortId}")]
        public async Task<IActionResult> ChiTietChuongtrinhDaoTao(int majorId, int cohortId)
        {
            try
            {
                if (_context.Knowledge_Courses != null)
                {
                    var value = await _context.Knowledge_Courses.Include(e => e.BlockOfKnowledge).Include(e => e.Course).Include(e => e.Cohort_Major).ThenInclude(e => e.Cohort).Include(e => e.Cohort_Major)
                        .ThenInclude(e => e.Major).Where(e => e.MajorId == majorId && e.CohortId == cohortId).ToListAsync();
                    var values = await _context.Knowledge_Courses.Where(e => e.MajorId == majorId && e.CohortId == cohortId).ToListAsync();
                    if (values != null)
                    {

                        var result = _mapper.Map<IEnumerable<BlockOfKnowledge_CourseDto>>(value);
                        //_response.Result = values;
                        _response.Result = new
                        {
                            
                            CohortMajor = new  {
                                CohortId = result.First().CohortId,
                                MajorId = result.First().MajorId,
                                MajorName = value.FirstOrDefault(e => e.MajorId == majorId)?.Cohort_Major?.Major?.MajorName,
                                CohortName = value.FirstOrDefault(e => e.CohortId == cohortId)?.Cohort_Major?.Cohort?.CohortName,
                            },
                            Courses = value.Select(x => new
                            {
                                BlockOfKnowledgeName = new
                                {
                                    BlockOfKnowledgeId = x.BlockOfKnowledgeId,
                                    BlockOfKnowledgeName = x.BlockOfKnowledge.BlockOfKnowledgeName
                                },
                                CourseName = new
                                {
                                    CourseId = x.CourseId,
                                    CourseCode = x.Course?.CourseCode,
                                    CourseName = x.Course?.CourseName
                                  
                                }
                            })
                            .GroupBy(x => x.BlockOfKnowledgeName)
                            .Select(group => new
                            {
                                BlockOfKnowledgeName = group.Key,
                                Courses = group.Select(x => x.CourseName).ToList()
                            })
                            .ToList()
                             
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

        [HttpPost]
        public async Task<IActionResult> Create(BlockOfKnowledge_CourseDto dto)
        {
            try
            {
                if (_context.Knowledge_Courses != null)
                {
                    BlockOfKnowledge_Course value = _mapper.Map<BlockOfKnowledge_Course>(dto);

                    await _context.AddAsync(value);
                    await _context.SaveChangesAsync();
                    _response.Result = _mapper.Map<BlockOfKnowledge_CourseDto>(value);
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int majorId, int cohortId, int courseId, int blockId)
        {
            try
            {
                if(_context.Knowledge_Courses != null)
                {
                    var blockC = await _context.Knowledge_Courses.FirstOrDefaultAsync(c => c.MajorId == majorId &&  c.CohortId == cohortId && c.CourseId == courseId && c.BlockOfKnowledgeId == blockId);
                    if(blockId != null)
                    {
                        _context.Knowledge_Courses.Remove(blockC);
                        _response.Result = _mapper.Map<BlockOfKnowledge_CourseDto>(blockC);
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
                return NotFound(_response);
            }
        }


        [HttpPost("CopyCTDT/{majorId}/{cohortIdTo}/{cohortIdFrom}")]
        public async Task<IActionResult> CopyCTDT(int majorId, int cohortIdTo, int cohortIdFrom)
        {
            try
            {
                if(_context.Knowledge_Courses != null)
                {
                    var oldKC = await _context.Knowledge_Courses.FirstOrDefaultAsync(c => c.MajorId == majorId && c.CohortId == cohortIdFrom);
                    if(oldKC == null)
                    {
                        var listKM = await _context.Knowledge_Courses.Where(c => c.MajorId == majorId && c.CohortId == cohortIdTo).ToListAsync();
                        
                        foreach(var c in listKM)
                        {
                            BlockOfKnowledge_Course blockCM = new()
                            {
                                CohortId = cohortIdFrom,
                                MajorId = majorId,
                                CourseId = c.CourseId,
                                BlockOfKnowledgeId = c.BlockOfKnowledgeId
                            };
                            
                            await _context.AddAsync(blockCM);
                            await _context.SaveChangesAsync();
                        }
                      
                        
                        _response.Message = "Copy successful";
                        return Ok(_response);
                    }
                    _response.Result = _mapper.Map<BlockOfKnowledge_CourseDto>(oldKC);
                    return Ok(_response);
                }
                _response.Message = "Table does not exit";
                _response.IsSuccess = false;
                return BadRequest(_response);

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
        }
    }
}
