using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Database
{
    public class TansiqyContext : DbContext
    {

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FacultyUniversity> FacultyUniversities { get; set; }
        public DbSet<FacultyDegree> FacultyDegrees { get; set; }
        public DbSet<UniversityDepartment> UniversityDepartments { get; set; }
        public DbSet<DegreeDepartment> DegreeDepartments { get; set; }
        public TansiqyContext(DbContextOptions<TansiqyContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // FacultyUniversity: composite key
            mb.Entity<FacultyUniversity>()
                .HasKey(fu => new { fu.FID, fu.UniID });

            mb.Entity<FacultyUniversity>()
                .HasOne(fu => fu.Faculty)
                .WithMany(f => f.FacultyUniversities)
                .HasForeignKey(fu => fu.FID);

            mb.Entity<FacultyUniversity>()
                .HasOne(fu => fu.University)
                .WithMany(u => u.FacultyUniversities)
                .HasForeignKey(fu => fu.UniID);

            // FacultyDegree: composite key
            mb.Entity<FacultyDegree>()
                .HasKey(fd => new { fd.FID, fd.DegID });

            mb.Entity<FacultyDegree>()
                .HasOne(fd => fd.Faculty)
                .WithMany(f => f.FacultyDegrees)
                .HasForeignKey(fd => fd.FID);

            mb.Entity<FacultyDegree>()
                .HasOne(fd => fd.Degree)
                .WithMany(d => d.FacultyDegrees)
                .HasForeignKey(fd => fd.DegID);

            // UniversityDepartment: composite key
            mb.Entity<UniversityDepartment>()
                .HasKey(ud => new { ud.UniID, ud.DepID });

            mb.Entity<UniversityDepartment>()
                .HasOne(ud => ud.University)
                .WithMany(u => u.UniversityDepartments)
                .HasForeignKey(ud => ud.UniID);

            mb.Entity<UniversityDepartment>()
                .HasOne(ud => ud.Department)
                .WithMany(d => d.UniversityDepartments)
                .HasForeignKey(ud => ud.DepID);

            // DegreeDepartment: composite key
            mb.Entity<DegreeDepartment>()
                .HasKey(dd => new { dd.DegID, dd.DepID });

            mb.Entity<DegreeDepartment>()
                .HasOne(dd => dd.Degree)
                .WithMany(d => d.DegreeDepartments)
                .HasForeignKey(dd => dd.DegID);

            mb.Entity<DegreeDepartment>()
                .HasOne(dd => dd.Department)
                .WithMany(d => d.DegreeDepartments)
                .HasForeignKey(dd => dd.DepID);

            // Department: Faculty relationship
            mb.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Departments)
                .HasForeignKey(d => d.FID);

            // User: Degree relationship
            mb.Entity<User>()
                .HasOne(u => u.Degree)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DegID);

            base.OnModelCreating(mb);
        }
       
    }
}
