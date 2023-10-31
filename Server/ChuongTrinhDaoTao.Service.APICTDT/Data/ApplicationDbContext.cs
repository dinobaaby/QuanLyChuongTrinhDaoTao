
using ChuongTrinhDaoTao.Service.APICTDT.Models;
using ChuongTrinhDaoTao.Service.APICTDT.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChuongTrinhDaoTao.Service.APICTDT.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }
        public DbSet<Cohort_Major> Cohort_Majors { get; set; }
     
        public DbSet<BlockOfKnowledge> BlocksOfKnowledge { get; set; }
       
        public DbSet<Course> Courses { get; set; }
        public DbSet<BlockOfKnowledge_Course> Knowledge_Courses { get; set; }
        public DbSet<UserMajor> UserMajor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Faculty>(entity =>
            {
                entity.ToTable(nameof(Faculty));

            });
            builder.Entity<Major>(entity =>
            {
                entity.ToTable(nameof(Major));
                entity.HasOne(e => e.Faculty).WithMany(e => e.Majors).HasForeignKey(e => e.FacultyId);
            });
            builder.Entity<Cohort>(entity =>
            {
                entity.ToTable(nameof(Cohort));

            });
            builder.Entity<Cohort_Major>(entity =>
            {
                entity.ToTable(nameof(Cohort_Major));
                entity.HasKey(e => new {e.CohortId, e.MajorId});
                entity.HasOne(e => e.Cohort).WithMany(e => e.CohortMajors).HasForeignKey(entity => entity.CohortId);
                entity.HasOne(e => e.Major).WithMany(e => e.MajorCohorts).HasForeignKey(e => e.MajorId);
            });
           
            builder.Entity<BlockOfKnowledge>(entity =>
            {
                entity.ToTable(nameof(BlockOfKnowledge));
            });
          
            builder.Entity<Course>(entity =>
            {
                entity.ToTable(nameof(Course));
            });
            builder.Entity<BlockOfKnowledge_Course>(entity =>
            {
                entity.ToTable(nameof(BlockOfKnowledge_Course));
                entity.HasKey(e => new { e.BlockOfKnowledgeId, e.CourseId ,e.MajorId, e.CohortId});
                entity.HasOne(e => e.BlockOfKnowledge).WithMany(e => e.BlockCourses).HasForeignKey(e => e.BlockOfKnowledgeId);
                entity.HasOne(e => e.Course).WithMany(e => e.CourseBlocks).HasForeignKey(e => e.CourseId);
                

            });
            builder.Entity<UserMajor>(entity =>
            {
                entity.ToTable(nameof(UserMajor));
                entity.HasKey(e => new { e.UserId, e.MajorId });
                entity.HasOne(e => e.User).WithMany(e => e.UserMajors).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Major).WithMany(e => e.MajorsUser).HasForeignKey(e => e.MajorId);
                entity.HasOne(e => e.Cohort).WithMany(e => e.UserMajor).HasForeignKey(e => e.CohortId);
            });

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationUser>(entity =>
            {
               
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
