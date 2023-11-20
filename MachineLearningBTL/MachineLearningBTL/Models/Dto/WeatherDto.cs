namespace MachineLearningBTL.Models.Dto
{
    public class WeatherDto
    {
     
        public DateTime created_at { get; set; }
        public int entry_id { get; set; }
        public float DoAm {  get; set; }
        public float NhietDo { get; set; }
        public float DoOn { get; set; }
        public float AnhSang { get; set; }
        public float KhiGas { get; set; }
        public string TrangThai { get; set; }

    }
}
