using System.ComponentModel.DataAnnotations;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    public class TuitionType
    {

        [Key]
        public int TuitionTypeId { get; set; }

        [Required]
        public string TuitionTypename { get; set; }

        public virtual ICollection<Tuition>? Tuitions { get; set;}
    }
}
