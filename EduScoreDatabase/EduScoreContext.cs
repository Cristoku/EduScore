using Microsoft.EntityFrameworkCore;

namespace EduScoreDatabase
{
    /// <summary>
    /// Represents the database context for the EduScore application.
    /// </summary>
    public class EduScoreContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet representing the collection of students in the database.
        /// </summary>
        public DbSet<Student> Students { get; set; }
        
        /// <summary>
        /// Gets or sets the DbSet representing the collection of subjects in the database.
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }
        
        /// <summary>
        /// Gets or sets the DbSet representing the collection of grades in the database.
        /// </summary>
        public DbSet<Grade> Grades { get; set; }
        
        /// <summary>
        /// Gets or sets the DbSet representing the collection of lesson plans in the database.
        /// </summary>
        public DbSet<LessonPlan> LessonPlans { get; set; }
        
        /// <summary>
        /// Gets or sets the DbSet representing the collection of teachers in the database.
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }

        /// <summary>
        /// Configures the database context to use the SQLite database with the specified connection string.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used for configuring the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EduScore.db");
        }

        /// <summary>
        /// Configures the relationships between entities using the Fluent API.
        /// </summary>
        /// <param name="modelBuilder">The model builder used for configuring entity relationships.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany()
                .HasForeignKey(g => g.SubjectId);

            modelBuilder.Entity<LessonPlan>()
                .HasOne(lp => lp.Subject)
                .WithMany()
                .HasForeignKey(lp => lp.SubjectId);
        }
    }
}