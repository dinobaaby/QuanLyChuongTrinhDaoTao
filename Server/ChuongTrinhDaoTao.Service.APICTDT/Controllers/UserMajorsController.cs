using AutoMapper;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMajorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected ResponseDto _response;
        private IMapper _mapper;
        public UserMajorsController(ApplicationDbContext context, IMapper mapper)
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
                if(_context.UserMajor == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Table is not exit";
                    return BadRequest(_response);
                }
                var result = await _context.UserMajor.ToListAsync();
                _response.Result = _mapper.Map<IEnumerable<UserMajorDto>>(result);
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return BadRequest(_response);
        }
    }
}
