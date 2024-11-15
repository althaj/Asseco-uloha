using DatabazaOsob.CRUDService.DTO;

namespace DatabazaOsob.CRUDService.Service
{
    public interface IServiceManager
    {
        public OsobaDTO CreateOsoba(OsobaDTO osoba);

        public OsobaDTO GetOsoba(int id);
    }
}
