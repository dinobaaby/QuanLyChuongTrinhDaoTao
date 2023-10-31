using ChuongTrinhDaoTao.Service.APICTDT.Data;

namespace ChuongTrinhDaoTao.Service.APICTDT.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
