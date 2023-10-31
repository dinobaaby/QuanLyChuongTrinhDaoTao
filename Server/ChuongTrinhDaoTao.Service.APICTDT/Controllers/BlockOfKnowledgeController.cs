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
    public class BlockOfKnowledgeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected ResponseDto _response;
        private IMapper _mapper;

        public BlockOfKnowledgeController(ApplicationDbContext context, IMapper mapper)
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
                if(_context.BlocksOfKnowledge != null)
                {
                    var bok = await _context.BlocksOfKnowledge.ToListAsync();
                    _response.Result = _mapper.Map<IEnumerable<BlockOfKnowledgeDto>>(bok);
                    return Ok(_response);
                }
                _response.IsSuccess = false;
                _response.Message = "Table BlockOfKnowledge is not found";
                return NotFound(_response);


            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return BadRequest(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlockOfKnowledgeDto bokdto)
        {
            try
            {
                BlockOfKnowledge bok = _mapper.Map<BlockOfKnowledge>(bokdto);
                _context.Add(bok);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<BlockOfKnowledgeDto>(bok);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if(_context.BlocksOfKnowledge != null)
                {
                    var bol = await _context.BlocksOfKnowledge.FirstOrDefaultAsync(b => b.BlockOfKnowledgeId == id);
                    if (bol != null)
                    {
                        _response.Result = _mapper.Map<BlockOfKnowledgeDto>(bol);
                        return Ok(_response);
                    }
                    _response.IsSuccess = false;
                    _response.Message = "BlockOfKnowledge item is not in Database";
                    return BadRequest(_response);
                }
                _response.IsSuccess = false;
                _response.Message = "Table BlockOfKnowledge not found";
                return BadRequest(_response);
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        

        [HttpPut]
        public async Task<IActionResult> Update(BlockOfKnowledgeDto bokdto)
        {
            try
            {
                BlockOfKnowledge bok = _mapper.Map<BlockOfKnowledge>(bokdto);
                _context.BlocksOfKnowledge.Update(bok);
                await _context.SaveChangesAsync();
                _response.Result = _mapper.Map<BlockOfKnowledgeDto>(bok);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return BadRequest(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_context.BlocksOfKnowledge != null)
                {
                    var bol = await _context.BlocksOfKnowledge.FirstOrDefaultAsync(b => b.BlockOfKnowledgeId == id);
                    if (bol != null)
                    {
                        _context.BlocksOfKnowledge.Remove(bol);
                        await _context.SaveChangesAsync();
                        _response.Result = _mapper.Map<BlockOfKnowledgeDto>(bol);
                        _response.Message = "Delete successful";
                        return Ok(_response);
                    }
                    _response.IsSuccess = false;
                    _response.Message = "BlockOfKnowledge item is not in Database";
                    return BadRequest(_response);
                }
                _response.IsSuccess = false;
                _response.Message = "Table BlockOfKnowledge not found";
                return BadRequest(_response);
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
