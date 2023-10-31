using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    public class BlockOfKnowledge_Course
    {
        public int BlockOfKnowledgeId { get; set; }
        public int CourseId { get; set; }

        public int CohortId { get; set; }
        public int MajorId { get; set; }

        [ForeignKey("CohortId, MajorId")]
        public virtual Cohort_Major? Cohort_Major { get; set; }
        public virtual BlockOfKnowledge? BlockOfKnowledge { get; set; }
        public virtual Course? Course { get; set; }
    }
}
