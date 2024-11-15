using DatabazaOsob.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabazaOsob.Model.Context
{
    public class DatabazaOsobContext : DbContext
    {
        private string DbPath;

        public DatabazaOsobContext(string databaseFileName = "DatabazaOsob.db")
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Path.Join(Environment.GetFolderPath(folder), "DatabazaOsob");
            Directory.CreateDirectory(path);
            DbPath = Path.Join(path, databaseFileName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osoba>();
            modelBuilder.Entity<Bydliste>();
            modelBuilder.Entity<Kontakt>();
            modelBuilder.Entity<Narodnost>();
            modelBuilder.Entity<Stat>();
            modelBuilder.Entity<TypKontaktu>();
        }
    }
}
