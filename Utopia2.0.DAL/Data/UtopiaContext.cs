<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
=======
﻿using Utopia2._0.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 3ae2c814f4640dcc084fc5068c1ed36fa7571798
using Utopia2._0.Models;

namespace Utopia2._0.Data
{
    public class UtopiaContext : DbContext
    {
        public UtopiaContext(DbContextOptions<UtopiaContext> options) : base(options) { }
<<<<<<< HEAD
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
=======
        public DbSet<Antwoord> Antwoorden { get; set; }
        public DbSet<Gebouw> Gebouwen { get; set; }
        public DbSet<Lijn> Lijnen { get; set; }
        public DbSet<MeerkeuzeAntwoord> MeerkeuzeAntwoorden { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Vraag> Vragen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antwoord>().ToTable("Antwoord");
            modelBuilder.Entity<Gebouw>().ToTable("Gebouw");
            modelBuilder.Entity<Lijn>().ToTable("Lijn");
            modelBuilder.Entity<MeerkeuzeAntwoord>().ToTable("MeerkeuzeAntwoord");
            modelBuilder.Entity<Persoon>().ToTable("Persoon");
            modelBuilder.Entity<Station>().ToTable("Station");
            modelBuilder.Entity<Vraag>().ToTable("Vraag");
>>>>>>> 3ae2c814f4640dcc084fc5068c1ed36fa7571798
        }
    }
}
