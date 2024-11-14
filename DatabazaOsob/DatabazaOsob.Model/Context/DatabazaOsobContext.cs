using DatabazaOsob.Model.Entities;
using DatabazaOsob.Model.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DatabazaOsob.Model.Context
{
    public class DatabazaOsobContext : DbContext
    {
        public required DbSet<Osoba> Osoby { get; set; }
        public required DbSet<Bydliste> Bydliska { get; set; }
        public required DbSet<Kontakt> Kontakty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Path.Join(Environment.GetFolderPath(folder), "DatabazaOsob");
            Directory.CreateDirectory(path);
            var DbPath = Path.Join(path, "DatabazaOsob.db");

            List<Narodnost> narodnostValues = new List<Narodnost> 
            {
                new Narodnost { Hodnota = "Česká" },
                new Narodnost { Hodnota = "Slovenská"},
                new Narodnost { Hodnota = "Iná" }
            };

            List<Stat> statValues = new List<Stat> 
            { 
                new Stat { Hodnota = "Česká republika" },
                new Stat { Hodnota = "Slovenská republika" },
                new Stat { Hodnota = "Iný" }
            };

            List<TypKontaktu> typKontaktuValues = new List<TypKontaktu> 
            { 
                new TypKontaktu { Hodnota = "Telefón" },
                new TypKontaktu { Hodnota = "Email" }
            };

            optionsBuilder
                .UseSqlite($"Data Source={DbPath}")
                .UseSeeding((context, _) =>
                {
                    EnsureEnumerationEntities<Narodnost>(context, narodnostValues);
                    EnsureEnumerationEntities<Stat>(context, statValues);
                    EnsureEnumerationEntities<TypKontaktu>(context, typKontaktuValues);
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    await EnsureEnumerationEntitiesAsync<Narodnost>(context, narodnostValues, cancellationToken);
                    await EnsureEnumerationEntitiesAsync<Stat>(context, statValues, cancellationToken);
                    await EnsureEnumerationEntitiesAsync<TypKontaktu>(context, typKontaktuValues, cancellationToken);
                });
        }

        private void EnsureEnumerationEntities<T>(DbContext context, IEnumerable<T> values)
        where T : EnumerationEntity, new()
        {
            foreach (var value in values)
            {
                if (value == null)
                    continue;

                EnumerationEntity? entity = context.Set<T>().FirstOrDefault(e => e.Hodnota.CompareTo(value.Hodnota) == 0);
                if (entity == null)
                {
                    context.Set<T>().Add(value);
                }
            }
            context.SaveChanges();
        }

        private async Task EnsureEnumerationEntitiesAsync<T>(DbContext context, IEnumerable<T> values, CancellationToken cancellationToken)
        where T : EnumerationEntity, new()
        {
            foreach (var value in values)
            {
                if (value == null)
                    continue;

                EnumerationEntity? entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Hodnota.CompareTo(value.Hodnota) == 0, cancellationToken);
                if (entity == null)
                {
                    context.Set<T>().Add(value);
                }
            }
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
