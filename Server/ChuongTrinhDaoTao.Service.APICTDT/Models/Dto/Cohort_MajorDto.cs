
namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class Cohort_MajorDto
    {


        public int CohortId { get; set; }
        public int MajorId { get; set; }


        public virtual Cohort? Cohort { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<BlockOfKnowledge_Course> BlockOfKnowledge_Courses { get; set; }
    }
}
