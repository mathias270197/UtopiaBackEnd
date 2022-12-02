using Microsoft.EntityFrameworkCore;

using Utopia2._0.Models;

namespace Utopia2._0.Data
{
    public class UtopiaContext : DbContext
    {
        public UtopiaContext(DbContextOptions<UtopiaContext> options) : base(options) { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().ToTable("Answer");
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Line>().ToTable("Line");
            modelBuilder.Entity<MultipleChoiceAnswer>().ToTable("MultipleChoiceAnswer");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Station>().ToTable("Station");
            modelBuilder.Entity<Question>().ToTable("Question");
        }
    }
}
