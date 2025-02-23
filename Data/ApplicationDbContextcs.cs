using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnderservedCommunitiesLearningPlatform.Models;

namespace UnderservedCommunitiesLearningPlatform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<StudentModule> StudentModules { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Student and Module
            modelBuilder.Entity<StudentModule>()
                .HasKey(sm => new { sm.StudentID, sm.ModuleID }); // Composite primary key

            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.Student)
                .WithMany(s => s.StudentModules)
                .HasForeignKey(sm => sm.StudentID);

            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.Module)
                .WithMany(m => m.StudentModules)
                .HasForeignKey(sm => sm.ModuleID);

            // Configure one-to-many relationship between Teacher and Module
            modelBuilder.Entity<Module>()
                .HasOne(m => m.Teacher)
                .WithMany(t => t.Modules)
                .HasForeignKey(m => m.TeacherID);

            // Configure table names for Student and Teacher
            modelBuilder.Entity<Student>().ToTable("Students"); // Map Student to "Students" table
            modelBuilder.Entity<Teacher>().ToTable("Teachers"); // Map Teacher to "Teachers" table
        }
    }
}





