using ChuongTrinhDaoTao.Service.WebApi.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ChuongTrinhDaoTao.Service.WebApi.Models
{
    public class Cohort
    {
        [Key]
        [MaxLength(20)]
        [DisplayName("Mã khóa")]
        public string CohortId {  get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên nghành phải có độ dài từ {2} đến {1}")]
        [DisplayName("Tên nghành")]
        public string CohortName { get; set; }

        [MaxLength(100)]
        [AllowNull]
        [DisplayName("Mô tả")]
        public string CohortDescription { get; set; }
        [Required]
        public DateTime StartDay { get; set; }

        [Required]
        public DateTime EndDay { get; set; }

        public string MajorId {  get; set; }

        public virtual Major? Major { get; set; }
        public virtual ICollection<ApplicationUser>? User { get; set; }
    
    }
}
