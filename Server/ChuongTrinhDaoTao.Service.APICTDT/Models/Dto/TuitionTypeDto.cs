

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class TuitionTypeDto
    {
       
        public int TuitionTypeId { get; set; }

    
        public string TuitionTypename { get; set; }

        public virtual ICollection<Tuition>? Tuitions { get; set; }
    }
}
