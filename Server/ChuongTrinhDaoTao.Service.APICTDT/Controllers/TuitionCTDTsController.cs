using AutoMapper;
using Azure;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionCTDTsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;
        public TuitionCTDTsController(IConfiguration configuration, IMapper mapper, ApplicationDbContext context)
        {
            _configuration = configuration;
            _response = new ResponseDto();
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            List<object> list = new List<object>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbDefault"));
            string query = "SELECT t.TuitionId, m.MajorId, c.CohortId,MajorName, CohortName, COUNT(CourseName) as ToTalC,SUM(CodeCredits) as CodeCreditsTotal, Tuition = SUM(cr.CodeCredits) * Price,TuitionRequire = SUM(cr.CodeCredits) * Price * 0.7, TuitionName  from BlockOfKnowledge_Course cm\r\nINNER JOIN Major m on m.MajorId = cm.MajorId\r\nINNER JOIN TuitionCTDT tm on tm.CohortId = cm.CohortId AND tm.MajorId = cm.MajorId\r\nINNER JOIN Tuition t on t.TuitionId = tm.TuitionId\r\nINNER JOIN Cohort c on c.CohortId = cm.CohortId\r\nINNER JOIN Course cr on cr.CourseId = cm.CourseId\r\nGROUP BY m.MajorName, c.CohortName, t.Price, t.TuitionName, t.TuitionId,m.MajorId, c.CohortId";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var obj = new
                {
                    TuitionId = int.Parse(dt.Rows[i]["TuitionId"].ToString()),
                    MajorId = int.Parse(dt.Rows[i]["MajorId"].ToString()),
                    CohortId = int.Parse(dt.Rows[i]["CohortId"].ToString()),
                    MajorName = (dt.Rows[i]["MajorName"].ToString()),
                    CohortName = (dt.Rows[i]["CohortName"].ToString()),
                    ToTalC = float.Parse(dt.Rows[i]["ToTalC"].ToString()),
                    CodeCreditsTotal = float.Parse(dt.Rows[i]["CodeCreditsTotal"].ToString()),
                    Tuition = float.Parse(dt.Rows[i]["Tuition"].ToString()),
                    TuitionRequire = float.Parse(dt.Rows[i]["TuitionRequire"].ToString()),
                    TuitionName = (dt.Rows[i]["TuitionName"].ToString()),
                };
            list.Add(obj);
            }
            _response.Result = list;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TuitionCTDTDto dto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbDefault")))
                {
                    con.Open();
                    string query = "INSERT INTO TuitionCTDT (TuitionId, CohortId, MajorId) VALUES (@Value1, @Value2, @Value3)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Value1", dto.TuitionId);
                    cmd.Parameters.AddWithValue("@Value2", dto.CohortId);
                    cmd.Parameters.AddWithValue("@Value3", dto.MajorId);

                    int rowAffected = await cmd.ExecuteNonQueryAsync();
                    if(rowAffected > 0)
                    {
                        _response.Message = "Insert successful";
                        return Ok(_response);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.Message = "Insert failed";
                        return BadRequest(_response);
                    }
                }
            }catch (Exception ex)
            {
                _response.IsSuccess=false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpDelete("{tuitionId}/{majorId}/{cohortId}")]
        public async Task<IActionResult> Detelte(int tuitionId, int majorId, int cohortId)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DbDefault")))
                {
                    con.Open();
                    string query = "DELETE FROM TuitionCTDT WHERE TuitionId = @tuitionId AND MajorId = @majorId AND CohortId = @cohortId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@tuitionId", tuitionId);
                    cmd.Parameters.AddWithValue("@majorId", majorId);
                    cmd.Parameters.AddWithValue("@cohortId", cohortId);

                    int rowAffected = await cmd.ExecuteNonQueryAsync();
                    if(rowAffected > 0)
                    {
                        _response.Message = "Delete success full";
                        return Ok(_response);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.Message = "Delete failed";
                        return BadRequest(_response);
                    }
                }
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }
       
    }
}
