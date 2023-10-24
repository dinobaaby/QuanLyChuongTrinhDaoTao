using System.ComponentModel.DataAnnotations.Schema;

namespace ChuongTrinhDaoTao.Service.WebApi.Models.Dto
{
    public class FacultyDto
    {
        public string FacultyId { get; set; }

        public string FacultyName { get; set; }

        public string FacultyDescription { get; set; }

        [NotMapped]
        public int MajorCount { get; set; }
    }
}
