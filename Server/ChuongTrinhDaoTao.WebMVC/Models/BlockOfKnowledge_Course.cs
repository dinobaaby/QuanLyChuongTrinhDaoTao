namespace ChuongTrinhDaoTao.WebMVC.Model
{
    public class BlockOfKnowledge_Course
    {
        public int BlockOfKnowledgeId { get; set; }
        public int CourseId { get; set; }

        public int CohortId { get; set; }
        public int MajorId { get; set; } 
    }
}
