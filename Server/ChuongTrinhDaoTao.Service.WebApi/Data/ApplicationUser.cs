using ChuongTrinhDaoTao.Service.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ChuongTrinhDaoTao.Service.WebApi.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(150)]
        public override string Id { get; set; }

        [DefaultValue("default.png")]
        [AllowNull]
        [MaxLength(50)]
        public string Avt {  get; set; }


        [MaxLength(50)]
        [DisplayName("Tên đầy đủ")]
        public string FullName { get; set; }

        public string CohortId { get; set; }
        public virtual Cohort? Cohort { get; set; }
    }
}
