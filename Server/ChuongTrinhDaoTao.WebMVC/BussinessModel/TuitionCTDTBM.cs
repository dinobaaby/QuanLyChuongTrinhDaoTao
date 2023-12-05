namespace ChuongTrinhDaoTao.WebMVC.BussinessModel
{
    public class TuitionCTDTBM
    {
        public int TuitionId { get; set; }
        public int MajorId { get; set; }
        public int CohortId { get; set; }
        public string MajorName { get; set; }
        public string CohortName { get; set;}
        public float TotalC {  get; set; }
        public float CodeCreditsTotal { get; set; }
        public float Tuition {  get; set; }
        public float TuitionRequire { get; set; }
        public string TuitionName { get; set; }
    }
}
