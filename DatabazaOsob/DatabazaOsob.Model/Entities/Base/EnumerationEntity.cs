using System.ComponentModel.DataAnnotations;

namespace DatabazaOsob.Model.Entities.Base
{
    public class EnumerationEntity : Entity
    {
        [Required, MaxLength(100)]
        public string Hodnota { get; set; } = string.Empty;
    }
}
