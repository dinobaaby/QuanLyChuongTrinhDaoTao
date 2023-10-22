using AutoMapper;

namespace ChuongTrinhDaoTao.Service.WebApi.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configs =>
            {
                configs.CreateMap<string, string>();
            });
            return mappingConfig;
        }
    }
}
