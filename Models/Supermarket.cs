using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Supermarket")]
    public class Supermarket
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Column("Ime")]
        [MaxLength(40)]
        public string Ime { get; set; }

        [Required]
        [Column("Grad")]
        [MaxLength(40)]
        public string Grad { get; set; }

        [JsonIgnore]
        public virtual List<Red> Redovi { get; set; }

        [JsonIgnore]
        public virtual List<Skladiste> Skladista { get; set; }
    }
}