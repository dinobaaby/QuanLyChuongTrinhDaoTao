using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace ChuongTrinhDaoTao.Service.WebApi.Models
{
    
    public class Faculty
    {
        [Key]
        [MaxLength(20)]
        public string FacultyId { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Tên khoa phải có độ dài từ {2} đến {1}")]
        [DisplayName("Tên khoa")]
        public string FucultyName { get; set; }


        [MaxLength(100)]
        [AllowNull]
        [DisplayName("Mô tả")]
        public string FacultyDescription { get; set; }

        

        public virtual ICollection<Major>? Majors { get; set; }
    }
}
