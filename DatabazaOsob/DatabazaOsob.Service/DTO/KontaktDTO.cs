using DatabazaOsob.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabazaOsob.Model.Entities
{
    [Table("Kontakt")]
    public class KontaktDTO : Entity
    {
        public required virtual TypKontaktuDTO TypKontaktu { get; set; }

        [MaxLength(100)]
        public required string Hodnota { get; set; }

        public required int OsobaId { get; set; }


        public required virtual OsobaDTO Osoba { get; set; }
    }
}