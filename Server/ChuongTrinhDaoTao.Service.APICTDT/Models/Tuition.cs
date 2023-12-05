using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    public class Tuition
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


        [ForeignKey("TuitionTypeId")]
        public virtual TuitionType? tuitionType { get; set; }
        public virtual ICollection<TuitionCTDT>? TuitionCTDTs { get; set; }
    }
}
