using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    
    public class Faculty
    {
        [Key]
        [MaxLength(20)]
        public string FacultyId { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Tên khoa phải có độ dài từ {2} đến {1}")]
        [DisplayName("Tên khoa")]
        public string FacultyName { get; set; }


        [MaxLength(100)]
        [AllowNull]
        [DisplayName("Mô tả")]
        public string FacultyDescription { get; set; }

        [NotMapped]
        public int MajorCount { get; set; }

        public virtual ICollection<Major>? Majors { get; set; }
    }
}
