using DatabazaOsob.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabazaOsob.Model.Entities
{
    [Table("Bydliste")]
    public class Bydliste : Entity
    {
        [MaxLength(100)]
        public string? Ulice { get; set; }

        [Required, MaxLength(50)]
        public string Mesto { get; set; } = null!;

        [Required, MaxLength(10)]
        public string PSC { get; set; } = null!;


        [Required]
        public virtual Stat Stat { get; set; } = null!;
    }
}