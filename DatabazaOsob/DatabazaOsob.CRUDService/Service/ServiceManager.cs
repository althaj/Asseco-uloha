using AutoMapper;
using DatabazaOsob.CRUDService.DTO;
using DatabazaOsob.Model.Entities;
using Microsoft.Extensions.Logging;

namespace DatabazaOsob.CRUDService.Service
{
    public class ServiceManager : IServiceManager
    {
        private Mapper mapper;
        private string? databaseFileName;

        private readonly ILogger<ServiceManager>? logger;

        public ServiceManager(string? databaseFileName = null)
        {
            mapper = InitializeAutomapper();
            this.databaseFileName = databaseFileName;
        }

        public ServiceManager(ILogger<ServiceManager> logger, string? databaseFileName = null)
        {
            mapper = InitializeAutomapper();
            this.databaseFileName = databaseFileName;

            this.logger = logger;
            logger.LogDebug($"NLog injected into {typeof(ServiceManager).Name}.");
        }

        private Mapper InitializeAutomapper()
        {
            logger?.LogInformation($"Initializing Automapper.");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OsobaDTO, Osoba>()
                    .ForMember(
                        entity => entity.Narodnost,
                        opt => opt.MapFrom(dto => new Narodnost { Hodnota = dto.Narodnost })
                    );
                cfg.CreateMap<Osoba, OsobaDTO>()
                    .ForMember(
                        dto => dto.Narodnost,
                        opt => opt.MapFrom(entity => entity.Narodnost.Hodnota)
                    );

                cfg.CreateMap<BydlisteDTO, Bydliste>()
                    .ForMember(
                        entity => entity.Stat,
                        opt => opt.MapFrom(dto => new Stat { Hodnota = dto.Stat })
                    );
                cfg.CreateMap<Bydliste, BydlisteDTO>()
                    .ForMember(
                        dto => dto.Stat,
                        opt => opt.MapFrom(entity => entity.Stat.Hodnota)
                    );

                cfg.CreateMap<KontaktDTO, Kontakt>()
                    .ForMember(
                        entity => entity.TypKontaktu,
                        opt => opt.MapFrom(dto => new TypKontaktu { Hodnota = dto.TypKontaktu })
                    );
                cfg.CreateMap<Kontakt, KontaktDTO>()
                    .ForMember(
                        dto => dto.TypKontaktu,
                        opt => opt.MapFrom(entity => entity.TypKontaktu.Hodnota)
                    );
            });

            logger?.LogInformation($"Automapper succesfully initialized.");

            return new Mapper(config);
        }

        public OsobaDTO CreateOsoba(OsobaDTO osobaDTO)
        {
            logger?.LogInformation("Creating osoba with entity {0}", osobaDTO);
            CRUDService<Osoba> osobaService = new CRUDService<Osoba>(databaseFileName);

            var osoba = mapper.Map<Osoba>(osobaDTO);

            PrepareOsoba(osoba);

            var result = osobaService.Create(osoba);
            return mapper.Map<OsobaDTO>(result);
        }

        public OsobaDTO GetOsoba(int id)
        {
            logger?.LogInformation("Getting osoba with id {0}", id);
            OsobaCRUDService osobaService = new OsobaCRUDService(databaseFileName);
            var result = osobaService.Read(id);
            return mapper.Map<OsobaDTO>(result);
        }

        private void PrepareOsoba(Osoba osoba)
        {
            logger?.LogInformation("Preparing osoba with entity {0}", osoba);

            if (string.IsNullOrEmpty(osoba.RodnePrijmeni))
                osoba.RodnePrijmeni = osoba.Prijmeni;

            foreach(Kontakt kontakt in osoba.Kontakty)
            {
                kontakt.Osoba = osoba;
            }
        }
    }
}
