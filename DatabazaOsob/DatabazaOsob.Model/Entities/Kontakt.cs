using DatabazaOsob.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabazaOsob.Model.Entities
{
    [Table("Kontakt")]
    public class Kontakt : Entity
    {
        [Required]
        public virtual TypKontaktu TypKontaktu { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Hodnota { get; set; } = null!;

        [Required]
        public int OsobaId { get; set; }


        public virtual Osoba Osoba { get; set; } = null!;
    }
}