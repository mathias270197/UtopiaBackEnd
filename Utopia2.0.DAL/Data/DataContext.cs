using Microsoft.EntityFrameworkCore;
using Utopia2._0.DAL.Models;

namespace Utopia2._0.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<GraduateProgram> GraduatePrograms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<GraduateProgram>().ToTable("GraduateProgram");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<MultipleChoiceAnswer>().ToTable("MultipleChoiceAnswer");          
            modelBuilder.Entity<Answer>().ToTable("Answer");
        }
    }
}
