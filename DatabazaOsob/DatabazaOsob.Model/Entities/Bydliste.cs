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

        [MaxLength(50)]
        public required string Mesto { get; set; }

        [MaxLength(10)]
        public required string PSC { get; set; }


        public required virtual Stat Stat { get; set; }
    }
}