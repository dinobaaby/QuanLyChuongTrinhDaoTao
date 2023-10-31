using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    public class BlockOfKnowledge
    {

        [Key]
        public int BlockOfKnowledgeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên nphải có độ dài từ {2} đến {1}")]
        [DisplayName("Tên")]
        public string BlockOfKnowledgeName { get; set; }

        public virtual ICollection<BlockOfKnowledge_Course>? BlockCourses { get; set; }
        
    }
}
