using ChuongTrinhDaoTao.Service.API.Data;
using ChuongTrinhDaoTao.Service.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChuongTrinhDaoTao.Service.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

           

            base.OnModelCreating(builder);
            builder.Entity<Cohort>(entity =>
            {
                entity.ToTable(nameof(Cohort));
                entity.HasOne(e => e.Major).WithMany(e => e.Cohorts).HasForeignKey(e => e.MajorId);
            });
            builder.Entity<Faculty>(entity =>
            {
                entity.ToTable(nameof(Faculty));
                entity.HasKey(e => e.FacultyId);
                entity.Property(e => e.FacultyName).HasColumnName("FucultyName");

            });
            builder.Entity<Major>(entity =>
            {
                entity.ToTable(nameof(Major));
                entity.HasKey(e => e.MajorId);
                entity.HasOne(e => e.Faculty).WithMany(e => e.Majors).HasForeignKey(e => e.FacultyId);
                
            });
            // Đổi tên bảng khi tao thông qua migration của identity security
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(e => e.Cohort).WithMany(e => e.User).HasForeignKey(e => e.CohortId);
            });
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
