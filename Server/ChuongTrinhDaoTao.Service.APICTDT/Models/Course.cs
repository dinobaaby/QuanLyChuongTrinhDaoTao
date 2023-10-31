using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [DisplayName("Tên học phần")]
        [StringLength(50, MinimumLength = 5)]
        public string CourseCode { get; set; }

        [AllowNull]
        [DisplayName("Mô tả")]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [Range(1, 4)]
        public int CodeCredits { get; set; }
        public string CourseMaterials { get; set; }

        public virtual ICollection<BlockOfKnowledge_Course>? CourseBlocks { get; set;}
    }
}
