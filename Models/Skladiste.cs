using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Skladiste")]
    public class Skladiste
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Broj")]
        public int Broj { get; set; }

        [Column("Velicina")]
        public int Velicina { get; set; }

       
        public virtual List<SProizvod> SProizvod { get; set; }

        [JsonIgnore]
        public Supermarket Supermarket { get; set; }
    }
}