using DatabazaOsob.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabazaOsob.Model.Entities
{
    [Table("Kontakt")]
    public class Kontakt : Entity
    {
        public required virtual TypKontaktu TypKontaktu { get; set; }

        [MaxLength(100)]
        public required string Hodnota { get; set; }

        public required int OsobaId { get; set; }


        public required virtual Osoba Osoba { get; set; }
    }
}