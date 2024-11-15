using DatabazaOsob.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabazaOsob.Model.Entities
{
    [Table("Osoba")]
    public class Osoba : Entity
    {
        [Required, MaxLength(50)]
        public string Jmeno { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Prijmeni { get; set; } = null!;

        [Required, MaxLength(50)]
        public string RodnePrijmeni { get; set; } = null!;

        [Length(10, 10)]
        public string? RodneCislo { get; set; }

        [Required]
        public DateTime DatumNarozeni {  get; set; }


        [Required]
        public virtual Narodnost Narodnost { get; set; } = null!;

        [Required]
        public virtual Bydliste Bydliste { get; set; } = null!;

        [Required]
        public virtual ICollection<Kontakt> Kontakty { get; set; } = null!;
    }
}
