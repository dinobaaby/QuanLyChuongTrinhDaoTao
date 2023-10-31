
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    public class Major
    {
        [Key]
        [MaxLength(20)]
        [DisplayName("Mã nghành")]
        public int MajorId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên nghành phải có độ dài từ {2} đến {1}")]
        [DisplayName("Tên nghành")]
        public string MajorName { get; set; }

        [MaxLength(100)]
        [AllowNull]
        [DisplayName("Mô tả")]
        public string MajorDescription { get; set; }


        [DisplayName("Ngày thành lập")]
        public DateTime MajorFounding { get; set; }

        public string FacultyId { get; set; }

        
        public virtual Faculty? Faculty { get; set; }
        public virtual ICollection<Cohort_Major>? MajorCohorts { get; set; }
        public virtual ICollection<UserMajor>? MajorsUser { get; set; }
    }
}
