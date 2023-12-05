using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.BussinessModel
{
    public class CourseBlockBM
    {
        public string BockOfKnowledgeName {  get; set; }
        public List<CourseDto> Courses {  get; set; }
    }
}
