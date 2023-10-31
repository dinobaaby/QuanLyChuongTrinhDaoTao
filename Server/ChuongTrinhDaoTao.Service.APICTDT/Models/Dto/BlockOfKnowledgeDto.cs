
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class BlockOfKnowledgeDto
    {

        
        public int BlockOfKnowledgeId { get; set; }

        
        public string BlockOfKnowledgeName { get; set; }

        public virtual ICollection<BlockOfKnowledge_Course>? BlockCourses { get; set; }

       
    }
}
