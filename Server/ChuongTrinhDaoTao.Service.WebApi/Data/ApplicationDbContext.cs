using ChuongTrinhDaoTao.Service.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChuongTrinhDaoTao.Service.WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Major> Major { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

           

            base.OnModelCreating(builder);

            builder.Entity<Faculty>(entity =>
            {
                entity.ToTable(nameof(Faculty));
                entity.HasKey(e => e.FacultyId);

            });
            builder.Entity<Major>(entity =>
            {
                entity.ToTable(nameof(Major));
                entity.HasKey(e => e.MajorId);
                entity.HasOne(e => e.Faculty).WithMany(e => e.Majors).HasForeignKey(e => e.FacultyId);
                entity.HasOne(e => e.User).WithOne(e => e.Major).HasForeignKey<Major>(e => e.UserID);
            });
            // Đổi tên bảng khi tao thông qua migration của identity security
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationUser>()
                   .Property(u => u.Id)
                   .HasMaxLength(150);
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        }

    }
}
