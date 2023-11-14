using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.Services.IService
{
    public interface ICohortMajorService
    {
        Task<ResponseDto?> CreateAsync(Cohort_MajorDto cohort_major);
        Task<ResponseDto?> UpdateAsync(Cohort_MajorDto cohort_major);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetMajorInCohortAsync(int cohortId);
        Task<ResponseDto?> GetCohortInMajorAsync(int majorId);
        Task<ResponseDto?> DeleteAsync(int majorId, int cohortId);
        Task<ResponseDto?> GetCohortMajorByIdAsync(int majorId, int cohortId);
    }
}
