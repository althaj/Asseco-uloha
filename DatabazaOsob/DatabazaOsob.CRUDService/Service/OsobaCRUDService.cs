using DatabazaOsob.CRUDService.Exceptions;
using DatabazaOsob.Model.Context;
using DatabazaOsob.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatabazaOsob.CRUDService.Service
{
    public class OsobaCRUDService : CRUDService<Osoba>
    {
        private readonly ILogger<OsobaCRUDService>? logger;

        public OsobaCRUDService(string? databaseFileName = null) : base(databaseFileName)
        {
        }

        public OsobaCRUDService(ILogger<OsobaCRUDService> logger, string? databaseFileName = null) : base(databaseFileName)
        {
            this.logger = logger;
            logger.LogDebug($"NLog injected into {typeof(OsobaCRUDService).Name}.");
        }

        public override Osoba Read(int id)
        {
            logger?.LogInformation("Getting entity of type {0} with ID {1}.", typeof(Osoba).Name, id);
            using (DatabazaOsobContext context = new DatabazaOsobContext(databaseFileName))
            {
                Osoba entity = context.Set<Osoba>()
                    .Where(o => o.Id == id)
                    .Include(o => o.Narodnost)
                    .Include(o => o.Bydliste).ThenInclude(b => b.Stat)
                    .Include(o => o.Kontakty).ThenInclude(k => k.TypKontaktu)
                    .FirstOrDefault() ?? throw new EntityNotFoundException(typeof(Osoba), id);
                return entity;
            }
        }

    }
}
