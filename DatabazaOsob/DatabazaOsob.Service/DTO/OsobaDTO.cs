using DatabazaOsob.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabazaOsob.Model.Entities
{
    [Table("Osoba")]
    public class OsobaDTO : Entity
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


        public required virtual NarodnostDTO Narodnost { get; set; }
        
        public required virtual BydlisteDTO Bydliste { get; set; }
        
        public required virtual IEnumerable<KontaktDTO> Kontakty { get; set; }
    }
}
