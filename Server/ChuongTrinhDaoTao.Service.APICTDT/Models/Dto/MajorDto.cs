

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class MajorDto
    {


  
        public int MajorId { get; set; }

     
        public string MajorName { get; set; }

     
        public string MajorDescription { get; set; }


        public DateTime MajorFounding { get; set; }

        public string FacultyId { get; set; }


        public virtual Faculty? Faculty { get; set; }
        public virtual ICollection<Cohort_Major>? MajorCohorts { get; set; }
        public virtual ICollection<UserMajor>? MajorsUser { get; set; }
    }

}
