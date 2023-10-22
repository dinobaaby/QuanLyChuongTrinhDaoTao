using ChuongTrinhDaoTao.Service.WebApi.Data;

namespace ChuongTrinhDaoTao.Service.WebApi.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
