using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.BussinessModel
{
    public class ChuongTrinhDaoTaoBM
    {
        public Cohort_MajorDto CohortMajor { get; set; }
        public List<BlockOfKnowledgeCourseBM> Courses { get; set; }
    }
}
