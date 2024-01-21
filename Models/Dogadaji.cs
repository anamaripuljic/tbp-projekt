using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbp_projekt.Models
{
    [Table(name: "Dogadaji")]
    public class Dogadaji
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_dogadaj")]
        public int Id_dogadaj { get; set; }
        [Column("Naziv_dogadaja")]
        public string Naziv_dogadaja { get; set; }
        [Column("Opis")]
        public string Opis { get; set; }
    }
}
