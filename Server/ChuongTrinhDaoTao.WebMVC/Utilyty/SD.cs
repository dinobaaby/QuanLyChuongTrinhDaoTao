namespace ChuongTrinhDaoTao.WebMVC.Utilyty
{
    public class SD
    {
        public static string FacultyApiBase { get; set; }
        public static string ApiBase { get; set; }
        public const string TrainningDepartment = "TRAINNINGDEPARTMENT";
        public const string Student = "STUDENT";
        public const string TokenCookie = "JwtToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
