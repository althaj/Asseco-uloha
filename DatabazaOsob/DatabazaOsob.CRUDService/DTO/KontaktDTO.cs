using DatabazaOsob.CRUDService.DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace DatabazaOsob.CRUDService.DTO
{
    public class KontaktDTO : EntityDTO
    {
        [Required, StringLength(100)]
        public string TypKontaktu { get; set; } = null!;

        [Required, StringLength(100)]
        public string Hodnota { get; set; } = null!;
    }
}