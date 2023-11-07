

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class CohortDto
    {

       
        public int CohortId { get; set; }

        
        public string CohortName { get; set; }

        
        public string CohortDescription { get; set; }
        
        public DateTime StartDay { get; set; }

    
        public DateTime EndDay { get; set; }
        
        public List<int> MajorIds { get; set; }
        public virtual ICollection<Cohort_MajorDto>? CohortMajors { get; set; }

        public virtual ICollection<UserMajorDto>? UserMajor { get; set; }
    }
}
