using Azure;
using CsvHelper;
using MachineLearningBTL.Models;
using MachineLearningBTL.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace MachineLearningBTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        private readonly MachineLearningDb _dbContext;
        protected ResponseDto _response;
        public DataSetController(MachineLearningDb dbContext)
        {    
            _dbContext = dbContext;
            _response = new ResponseDto();
        }

        [HttpPost]
        public async Task<IActionResult> AddDataFromCsv()
        {
            try
            {
                using (var reader = new StreamReader("D:\\HK5\\MachineLearning\\Data\\diabetes.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<DiaBetes>().ToList();

                    foreach (var record in records)
                    {
                        var diabetesRecord = new DiaBetes
                        {
                            Id = 0,
                            Pregnancies = record.Pregnancies,
                            Glucose = record.Glucose,
                            BloodPressure = record.BloodPressure,
                            SkinThickness = record.SkinThickness,
                            Insulin = record.Insulin,
                            BMI = record.BMI,
                            DiabetesPedigreeFunction = record.DiabetesPedigreeFunction,
                            Age = record.Age,
                            Outcome = record.Outcome
                        };

                        _dbContext.DiaBetes.Add(diabetesRecord);
                    }
                    await _dbContext.SaveChangesAsync();
                }
                    
                    return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding data: {ex.Message}");
            }
        }
        [HttpPost("AddDataWeather")]
        public async Task<IActionResult> AddDataWeather()
        {
            try
            {
                using (var reader = new StreamReader("D:\\HK5\\MachineLearning\\ExampleML\\test.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<WeatherDto>().ToList();

                    foreach (var record in records)
                    {
                        var diabetesRecord = new Weather
                        {
                            Id = 0,
                            CreateAt = record.created_at,
                            DoAm = record.DoAm,
                            NhietDo = record.NhietDo,
                            DoOn = record.DoOn,
                            AnhSang = record.AnhSang,
                            KhiGas = record.KhiGas,
                            TrangThai = record.TrangThai
                            
                        };

                        _dbContext.weathers.Add(diabetesRecord);
                    }
                    await _dbContext.SaveChangesAsync();
                }

                return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding data: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> DataTrainning()
        {
            try
            {
                if (_dbContext.Database != null)
                {
                    var result = await _dbContext.DiaBetes.ToListAsync();
                    _response.Result = result;
                    return Ok(result);
                }
                _response.IsSuccess = false;
                _response.Message = "Error";
                return BadRequest(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }


        [HttpPost("PostUserData")]
        public async Task<IActionResult> AddUserDataFromCsv()
        {
            try
            {
                using (var reader = new StreamReader("D:\\HK5\\MachineLearning\\ExampleML\\BTLKNN\\bca.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<PostDiabetes>().ToList();

                    foreach (var record in records)
                    {
                        var diabetesRecord = new UserData
                        {
                            Id = 0,
                            Pregnancies = record.Pregnancies,
                            Glucose = record.Glucose,
                            BloodPressure = record.BloodPressure,
                            SkinThickness = record.SkinThickness,
                            Insulin = record.Insulin,
                            BMI = record.BMI,
                            DiabetesPedigreeFunction = record.DiabetesPedigreeFunction,
                            Age = record.Age,
                            Outcome = record.Outcome
                        };

                        _dbContext.userDatas.Add(diabetesRecord);
                    }
                    await _dbContext.SaveChangesAsync();
                    return Ok("Successful");
                }
            } 
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding data: {ex.Message}");
            }
        }


    }
}
