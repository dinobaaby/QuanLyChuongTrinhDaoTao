using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    public class TuitionCTDT
    {
        public int TuitionId { get; set; }
        public int CohortId { get; set; }
        public int MajorId { get; set; }

        [ForeignKey("CohortId, MajorId")]
        public virtual Cohort_Major? Cohort_Major { get; set; }

        [ForeignKey("TuitionId")]
        public virtual Tuition? Tuition { get; set; }
    }
}
