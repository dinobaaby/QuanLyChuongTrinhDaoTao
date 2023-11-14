namespace ChuongTrinhDaoTao.WebMVC.BussinessModel
{
    public class BlockOfKnowledge_CourseBM
    {
        public int BlockOfKnowledgeId { get; set; }
        public int CourseId { get; set; }

        public int CohortId { get; set; }
        public int MajorId { get; set; }

        public string BlockOfKnowledgeName { get; set; }
        public string CourseName { get;  set; }

        public string CohortName { get; set; }
        public string MajorName { get; set;}
    
    }
}
