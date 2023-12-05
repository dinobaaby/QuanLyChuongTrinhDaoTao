using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class TuitionDto
    {
       
        public int TuitionId { get; set; }

       
        public string TuitionName { get; set; }

       
        public string TuitionDescription { get; set; }

        public float Price { get; set; }

        public int TuitionTypeId { get; set; }


        
        public virtual TuitionType? tuitionType { get; set; }
    }
}
