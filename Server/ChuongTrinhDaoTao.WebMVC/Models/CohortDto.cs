


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ChuongTrinhDaoTao.WebMVC.Models
{
    public class CohortDto
    {
        
        public int CohortId { get; set; }

        [Required]
        public string CohortName { get; set; }

        [Required]
        public string CohortDescription { get; set; }

        [Required]
        public DateTime StartDay { get; set; }

        [Required]
        public DateTime EndDay { get; set; }

        [NotMapped]
        [AllowNull]
        public List<int> MajorIds { get; set; }


    }
}
