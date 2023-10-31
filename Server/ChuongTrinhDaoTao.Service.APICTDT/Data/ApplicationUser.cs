using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using ChuongTrinhDaoTao.Service.APICTDT.Models;

namespace ChuongTrinhDaoTao.Service.APICTDT.Data
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

        public virtual ICollection<UserMajor>? UserMajors { get; set; }
       
    }
}
