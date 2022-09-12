using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Red")]
    public class Red
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Broj")]
        public int Broj { get; set; }

        [Column("Kategorija")]
        [MaxLength(40)]
        public string Kategorija { get; set; }

        
        public virtual List<Proizvod> Proizvodi { get; set; }

        [JsonIgnore]
        public Supermarket Supermarket { get; set; }
    }
}