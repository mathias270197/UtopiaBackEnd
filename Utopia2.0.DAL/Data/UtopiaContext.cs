using Microsoft.EntityFrameworkCore;

using Utopia2._0.Models;

namespace Utopia2._0.Data
{
    public class UtopiaContext : DbContext
    {
        public UtopiaContext(DbContextOptions<UtopiaContext> options) : base(options) { }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>().ToTable("Station");
            modelBuilder.Entity<Line>().ToTable("Line");
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<MultipleChoiceAnswer>().ToTable("MultipleChoiceAnswer");          
            modelBuilder.Entity<Answer>().ToTable("Answer");
        }
    }
}
