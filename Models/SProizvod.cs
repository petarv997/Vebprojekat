using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("SProizvod")]
    public class SProizvod
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        [MaxLength(40)]
        public string Naziv { get; set; }

        [Column("Kolicina")]
        [Range(0, 500)]
        public int Kolicina { get; set; }

        [JsonIgnore]
        public Skladiste Skladiste { get; set; }
    }
}