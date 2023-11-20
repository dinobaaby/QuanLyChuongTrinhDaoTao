using System.ComponentModel.DataAnnotations;

namespace MachineLearningBTL.Models
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public float DoAm {  get; set; }
        public float NhietDo { get; set; }
        public float DoOn { get; set; }
        public float AnhSang { get; set; }
        public float KhiGas { get; set; }
        public string TrangThai { get; set; }

    }
}
