

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.WebMVC.Models
{
    public class MajorDto
    {

       
        public int MajorId { get; set; }

        [Required]
        public string MajorName { get; set; }


        [Required]
        public string MajorDescription { get; set; }

        [Required]
        public DateTime MajorFounding { get; set; }


        [NotMapped]
        public string FacultyName { get; set; }

        [Required]
        public string FacultyId { get; set; }

    }
}
