using ChuongTrinhDaoTao.Service.API.Data;

namespace ChuongTrinhDaoTao.Service.API.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
