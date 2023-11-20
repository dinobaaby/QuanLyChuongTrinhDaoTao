using MachineLearningBTL.Models;
using MachineLearningBTL.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningBTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiabetesController : Controller
    {
        private readonly MachineLearningDb _dbContext;
        protected ResponseDto _response;

        public DiabetesController(MachineLearningDb dbContext)
        {
            _dbContext = dbContext;
            _response = new ResponseDto();
        }

        

        [HttpPost("predict")]
        public IActionResult PredictOutcome([FromBody] DiaBetes inputData)
        {
            int k = 13;
            var knn = KNearestNeighbor(inputData, k);
            float diabetes = knn.Where(c => c == "1").Count();
            float undiabetes = knn.Where(c => c == "0").Count();
            var predictedOutcome = FindMostOccur(knn);

            Object obj = new
            {
                PredictedOutcome = predictedOutcome == "0" ? "Undiabetes" : "Diabetes",
                Diseaseincidence = diabetes / knn.Count(),
                Undiseaseincidence = undiabetes / knn.Count()
            };
            _response.Result = obj;
            return Ok(_response);
        }

        private List<string> KNearestNeighbor(DiaBetes point, int k)
        {
            try
            {

                var distances = _dbContext.DiaBetes
                    .ToList() // Fetch the data from the database
                    .Select(item => new
                    {
                        Label = item.Outcome.ToString(),
                        Value = CalcDistances(item, point)
                    })
                    .OrderBy(x => x.Value)
                    .Take(k)
                    .Select(x => x.Label)
                    .ToList();

                return distances;


            }
            catch (Exception ex)
            {
                // Log the exception or return an error response
                return new List<string>();
            }
        }

        private double CalcDistances(DiaBetes pointA, DiaBetes pointB)
        {
            double tmp = 0;
            tmp += Math.Pow(pointA.Pregnancies - pointB.Pregnancies, 2);
            tmp += Math.Pow(pointA.Glucose - pointB.Glucose, 2);
            tmp += Math.Pow(pointA.BloodPressure - pointB.BloodPressure, 2);
            tmp += Math.Pow(pointA.SkinThickness - pointB.SkinThickness, 2);
            tmp += Math.Pow(pointA.Insulin - pointB.Insulin, 2);
            tmp += Math.Pow(pointA.BMI - pointB.BMI, 2);
            tmp += Math.Pow(pointA.DiabetesPedigreeFunction - pointB.DiabetesPedigreeFunction, 2);
            tmp += Math.Pow(pointA.Age - pointB.Age, 2);

            return Math.Sqrt(tmp);
        }

        private string FindMostOccur(List<string> arr)
        {
            var labels = arr.Distinct();
            string ans = string.Empty;
            int maxOccur = 0;

            foreach (var label in labels)
            {
                int num = arr.Count(x => x == label);
                if (num > maxOccur)
                {
                    maxOccur = num;
                    ans = label;
                }
            }

            return ans;
        }

        
    }
}
