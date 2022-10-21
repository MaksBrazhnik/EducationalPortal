using EducationalPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EducationalPortal.DAL.DBOperation
{
    public class EducationalPortalContext : DbContext
    {
        public EducationalPortalContext(DbContextOptions<EducationalPortalContext> options) : base(options)
        {
        }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<UserMaterial> UserMaterials { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<CourseMaterial> CourseMaterials { get; set; }

        public DbSet<CourseSkill> CourseSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
