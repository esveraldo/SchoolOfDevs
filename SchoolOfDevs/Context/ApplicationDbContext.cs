using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Mapping;

namespace SchoolOfDevs.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<User> ?Users { get; set; }
        public DbSet<Course> ?Courses { get; set; }
        public DbSet<Note> ?Notes { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new NoteMapping());
            modelBuilder.ApplyConfiguration(new CouseMapping());
            modelBuilder.ApplyConfiguration(new UserCourseMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=schoolofdevs;Trusted_Connection=False;MultipleActiveResultSets=true;user id=sa;password=esve6140");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
