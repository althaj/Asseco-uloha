using DatabazaOsob.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabazaOsob.Model.Entities
{
    [Table("Osoba")]
    public class Osoba : Entity
    {
        [MaxLength(50)]
        public required string Jmeno { get; set; }

        [MaxLength(50)]
        public required string Prijmeni { get; set; }

        [MaxLength(50)]
        public required string RodnePrijmeni { get; set; }

        [Length(10, 10)]
        public string? RodneCislo { get; set; }

        public required DateTime DatumNarozeni {  get; set; }


        public required virtual Narodnost Narodnost { get; set; }
        
        public required virtual Bydliste Bydliste { get; set; }
        
        public required virtual IEnumerable<Kontakt> Kontakty { get; set; }
    }
}
