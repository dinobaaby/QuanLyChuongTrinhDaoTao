using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class BlockOfKnowledge_CourseDto {
        public int BlockOfKnowledgeId { get; set; }
        public int CourseId { get; set; }

        public int CohortId { get; set; }
        public int MajorId { get; set; }


        public virtual Cohort_Major? Cohort_Major { get; set; }
        public virtual BlockOfKnowledge? BlockOfKnowledge { get; set; }
        public virtual Course? Course { get; set; }

    }
}
