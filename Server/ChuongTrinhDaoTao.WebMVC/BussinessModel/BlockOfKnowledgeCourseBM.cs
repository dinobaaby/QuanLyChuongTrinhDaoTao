using ChuongTrinhDaoTao.WebMVC.Model;
using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.BussinessModel
{
    public class BlockOfKnowledgeCourseBM
    {
        public BlockOfKnowledgeDto BlockOfKnowledgeName { get; set; }

        public List<CourseDto> Courses { get; set; }
    }
}
