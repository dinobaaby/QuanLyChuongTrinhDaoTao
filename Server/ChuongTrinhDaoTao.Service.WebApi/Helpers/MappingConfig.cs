using AutoMapper;
using ChuongTrinhDaoTao.Service.WebApi.Models;
using ChuongTrinhDaoTao.Service.WebApi.Models.Dto;

namespace ChuongTrinhDaoTao.Service.WebApi.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configs =>
            {
                configs.CreateMap<FacultyDto, Faculty>();
                configs.CreateMap<Faculty, FacultyDto>();
                configs.CreateMap<MajorDto, Major>();
                configs.CreateMap<Major, MajorDto>();   
            });
            return mappingConfig;
        }
    }
}
