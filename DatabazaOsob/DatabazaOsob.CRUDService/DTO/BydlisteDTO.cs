using DatabazaOsob.CRUDService.DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace DatabazaOsob.CRUDService.DTO
{
    public class BydlisteDTO : EntityDTO
    {

        [StringLength(100)]
        public string? Ulice { get; set; } = null!;

        [Required, StringLength(50)]
        public string Mesto { get; set; } = null!;

        [Required, StringLength(10)]
        public string PSC { get; set; } = null!;

        [Required, StringLength(100)]
        public string Stat { get; set; } = null!;
    }
}