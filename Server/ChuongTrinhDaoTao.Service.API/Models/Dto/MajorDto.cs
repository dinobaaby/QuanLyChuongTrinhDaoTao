using ChuongTrinhDaoTao.Service.API.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ChuongTrinhDaoTao.Service.API.Models.Dto
{
    public class MajorDto
    {
       
        public string MajorId { get; set; }

        public string MajorName { get; set; }

        public string MajorDescription { get; set; }

        public DateTime MajorFounding { get; set; }

        public string FacultyId { get; set; }

       

        

        public virtual Faculty? Faculty { get; set; }
    }
}
