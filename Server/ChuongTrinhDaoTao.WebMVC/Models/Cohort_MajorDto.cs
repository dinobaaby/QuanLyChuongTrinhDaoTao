
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.WebMVC.Models
{
    public class Cohort_MajorDto
    {
        [Required]
        public int CohortId { get; set; }
        [Required]
        public int MajorId { get; set; }

        [NotMapped]
        public string MajorName { get; set;}

        [NotMapped]
        public string CohortName { get; set;}

        
    }
}
