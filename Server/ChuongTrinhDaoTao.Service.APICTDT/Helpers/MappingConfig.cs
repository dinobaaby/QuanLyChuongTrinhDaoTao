using AutoMapper;
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;

namespace ChuongTrinhDaoTao.Service.APICTDT.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configs =>
            {
                configs.CreateMap<FacultyDto, Faculty>();
                configs.CreateMap<Faculty, FacultyDto>();

                configs.CreateMap<Major, MajorDto>();
                configs.CreateMap<MajorDto, Major>(); 

                configs.CreateMap<Cohort, CohortDto>();
                configs.CreateMap<CohortDto, Cohort>();

                configs.CreateMap<BlockOfKnowledge, BlockOfKnowledgeDto>();
                configs.CreateMap<BlockOfKnowledgeDto, BlockOfKnowledge>();

                configs.CreateMap<BlockOfKnowledge_Course, BlockOfKnowledge_CourseDto>();
                configs.CreateMap<BlockOfKnowledge_CourseDto, BlockOfKnowledge_Course>();

                configs.CreateMap<Course, CourseDto>();
                configs.CreateMap<CourseDto, Course>();

                configs.CreateMap<Cohort_Major, Cohort_MajorDto>();
                configs.CreateMap<Cohort_MajorDto, Cohort_Major>();

               
            });
            return mappingConfig;
        }
    }
}
