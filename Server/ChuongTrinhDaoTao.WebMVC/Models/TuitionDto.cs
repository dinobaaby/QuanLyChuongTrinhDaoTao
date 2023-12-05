using System.ComponentModel.DataAnnotations;

namespace ChuongTrinhDaoTao.WebMVC.Models
{
    public class TuitionDto
    {
        [Key]
        public int TuitionId { get; set; }

        [Required]
        public string TuitionName { get; set; }

        [Required]
        public string TuitionDescription { get; set; }

        [Required]
        public float Price { get; set; }

        public int TuitionTypeId { get; set; }
    }
}
