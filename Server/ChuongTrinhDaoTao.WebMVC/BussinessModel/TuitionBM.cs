using System.ComponentModel.DataAnnotations;

namespace ChuongTrinhDaoTao.WebMVC.BussinessModel
{
    public class TuitionBM
    {
       
        public int TuitionId { get; set; }

        
        public string TuitionName { get; set; }

        
        public string TuitionDescription { get; set; }

       
        public float Price { get; set; }

        public int TuitionTypeId { get; set; }

        public string TuitionTypeName { get; set; }
    }
}
