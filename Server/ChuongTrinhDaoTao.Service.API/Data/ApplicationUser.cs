using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChuongTrinhDaoTao.Service.API.Models;

namespace ChuongTrinhDaoTao.Service.API.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(150)]
        public override string Id { get; set; }

        [DefaultValue("default.png")]
        [AllowNull]
        [MaxLength(50)]
        public string Avt { get; set; }


        [MaxLength(50)]
        [DisplayName("Tên đầy đủ")]
        public string FullName { get; set; }

        public string CohortId { get; set; }
        public virtual Cohort? Cohort { get; set; }
    }
}
