

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class TuitionCTDTDto
    {
        public int TuitionId { get; set; }
        public int CohortId { get; set; }
        public int MajorId { get; set; }


        public virtual Cohort_Major? Cohort_Major { get; set; }
        public virtual Tuition? Tuition { get; set; }
    }
}
