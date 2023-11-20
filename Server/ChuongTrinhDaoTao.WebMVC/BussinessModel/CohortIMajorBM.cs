using ChuongTrinhDaoTao.WebMVC.Models;

namespace ChuongTrinhDaoTao.WebMVC.BussinessModel
{
    public class CohortIMajorBM
    {
        public string MajorName { get; set; }
        public IEnumerable<CohortBM> Cohorts { get; set; }
    }
}
