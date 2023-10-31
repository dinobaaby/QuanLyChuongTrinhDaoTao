
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class CourseDto
    {
       
        public int CourseId { get; set; }
        
        public string CourseCode { get; set; }

       
        public string CourseName { get; set; }

       
        public int CodeCredits { get; set; }
        public string CourseMaterials { get; set; }

        public virtual ICollection<BlockOfKnowledge_Course>? CourseBlocks { get; set; }
    }
}
