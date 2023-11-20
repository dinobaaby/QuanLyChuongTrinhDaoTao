namespace MachineLearningBTL.Models.Dto
{
    public class ResponseDto
    {
        public object? Result {  get; set; }
        public string Message { get; set; } = "";
        public bool IsSuccess { get; set; } = true;

    }
}
