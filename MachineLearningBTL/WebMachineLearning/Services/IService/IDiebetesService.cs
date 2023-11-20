using WebMachineLearning.Models;

namespace WebMachineLearning.Services.IService
{
    public interface IDiebetesService
    {
        Task<ResponseDto?> TestData(DiaBetes dto);
    }
}
