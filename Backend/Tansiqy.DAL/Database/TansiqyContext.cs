using Microsoft.EntityFrameworkCore;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Database
{
    public class TansiqyContext : DbContext
    {
        public TansiqyContext(DbContextOptions<TansiqyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DegreeDepartment>()
                .HasKey(dd => new { dd.DegID, dd.DepID });

            modelBuilder.Entity<FacultyDegree>()
                .HasKey(fd => new { fd.FID, fd.DegID });

            modelBuilder.Entity<UniversityDepartment>()
                .HasKey(ud => new { ud.UniID, ud.DepID });

            modelBuilder.Entity<FacultyUniversity>()
                .HasKey(fu => new { fu.FID, fu.UniID });

            modelBuilder.Entity<FacultyFavourite>()
                .HasKey(ff => new { ff.FID, ff.FavID });

            modelBuilder.Entity<User>()
            .HasOne(u => u.Degree)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.Degree_Id)
            .OnDelete(DeleteBehavior.SetNull);

       

        }


        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        public DbSet<FacultyUniversity> FacultyUniversities { get; set; }
        public DbSet<FacultyDegree> FacultyDegrees { get; set; }
        public DbSet<FacultyFavourite> FacultyFavourites { get; set; }
        public DbSet<UniversityDepartment> UniversityDepartments { get; set; }
        public DbSet<DegreeDepartment> DegreeDepartments { get; set; }
    }
}
