using AutoMapper;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
