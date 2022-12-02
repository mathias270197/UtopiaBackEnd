using Utopia2._0.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utopia2._0.Models;

namespace Utopia2._0.Data
{
    public class UtopiaContext : DbContext
    {
        public UtopiaContext(DbContextOptions<UtopiaContext> options) : base(options) { }
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
        }
    }
}
