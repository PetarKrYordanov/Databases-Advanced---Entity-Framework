namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(true);

                entity.Property(e => e.PhoneNumber).HasColumnType("Char(10)").IsRequired(false).IsUnicode(false);

                entity.Property(e => e.Birthday).IsRequired(false);

                entity.HasMany(e => e.CourseEnrollments)
                        .WithOne(d => d.Student)
                        .HasForeignKey(d => d.StudentId);

                entity.HasMany(e => e.HomeworkSubmissions)
                        .WithOne(d => d.Student)
                        .HasForeignKey(d => d.StudentId);
            });

            builder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                       .HasMaxLength(80).IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(80).IsRequired(false);

                entity.HasMany(e => e.HomeworkSubmissions)
                    .WithOne(d => d.Course)
                    .HasForeignKey(d => d.HomeworkId);

                entity.HasMany(e => e.StudentsEnrolled)
                    .WithOne(d => d.Course)
                    .HasForeignKey(d => d.CourseId);

                entity.HasMany(e => e.Resources)
                       .WithOne(d => d.Course)
                       .HasForeignKey(d => d.CourseId);
            });

            builder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode();

                entity.Property(e => e.Url).IsUnicode(false);

            });

            builder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.ContentType).IsRequired(false);

            });

            builder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });
            });

            builder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });
            });
        }

    }
}
