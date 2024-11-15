using DatabazaOsob.CRUDService.Exceptions;
using DatabazaOsob.Model.Context;
using DatabazaOsob.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabazaOsob.CRUDService.Service
{
    public class OsobaCRUDService : CRUDService<Osoba>
    {
        public OsobaCRUDService(string? databaseFileName = null) : base(databaseFileName) { }

        public override Osoba Read(int id)
        {
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
