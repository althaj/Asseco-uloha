using Altairis.ValidationToolkit;
using DatabazaOsob.CRUDService.DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace DatabazaOsob.CRUDService.DTO
{
    public class OsobaDTO : EntityDTO
    {

        [Required, MaxLength(50)]
        public string Jmeno { get; set; } = null!;

        [Required, StringLength(50)]
        public string Prijmeni { get; set; } = null!;

        [StringLength(50)]
        public string? RodnePrijmeni { get; set; }

        [RodneCislo]
        public string? RodneCislo { get; set; }

        [Required]
        public DateTime DatumNarozeni {  get; set; }

        [Required, StringLength(100)]
        public string Narodnost { get; set; } = null!;


        [Required]
        public virtual BydlisteDTO Bydliste { get; set; } = null!;

        [Required]
        public virtual IEnumerable<KontaktDTO> Kontakty { get; set; } = null!;
    }
}
