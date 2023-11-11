using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.WebMVC.Models
{
    public class FacultyDto
    {
        [Required]
        public string FacultyId { get; set; }
        [Required]
        public string FacultyName { get; set; }
        [Required]
        public string FacultyDescription { get; set; }

        [NotMapped]
        public int MajorCount { get; set; }
    }
}
