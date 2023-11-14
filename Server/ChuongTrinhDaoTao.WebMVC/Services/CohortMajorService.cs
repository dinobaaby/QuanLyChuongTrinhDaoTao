using ChuongTrinhDaoTao.WebMVC.Models;
using ChuongTrinhDaoTao.WebMVC.Services.IService;
using ChuongTrinhDaoTao.WebMVC.Utilyty;

namespace ChuongTrinhDaoTao.WebMVC.Services
{
    public class CohortMajorService : ICohortMajorService
    {
        private readonly IBaseService _baseService;
        public CohortMajorService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateAsync(Cohort_MajorDto cohort_major)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = cohort_major,
                Url = SD.ApiBase + "/api/CohortMajors"
            });
        }

        public async Task<ResponseDto?> DeleteAsync(int majorId, int cohortId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/CohortMajors/" + majorId + "/" + cohortId
            });
        }

        public async Task<ResponseDto?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/CohortMajors"
            });
        }

        public async Task<ResponseDto?> GetCohortInMajorAsync(int majorId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/CohortMajors/GetCohortInMajor/" + majorId
            });
        }

        public async Task<ResponseDto?> GetCohortMajorByIdAsync(int majorId, int cohortId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/CohortMajors/" + majorId + "/" + cohortId
            });
        }

        public async Task<ResponseDto?> GetMajorInCohortAsync(int cohortId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ApiBase + "/api/CohortMajors/GetMajorInCohort/" + cohortId
            });
        }

        public Task<ResponseDto?> UpdateAsync(Cohort_MajorDto cohort_major)
        {
            throw new NotImplementedException();
        }
    }
}
