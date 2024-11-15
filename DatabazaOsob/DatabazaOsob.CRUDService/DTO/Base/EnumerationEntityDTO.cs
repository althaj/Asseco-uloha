using System.ComponentModel.DataAnnotations;

namespace DatabazaOsob.CRUDService.DTO.Base
{
    public class EnumerationEntityDTO : EntityDTO
    {
        [Required, StringLength(100)]
        public string Hodnota { get; set; } = null!;
    }
}
