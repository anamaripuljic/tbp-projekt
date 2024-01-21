using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace tbp_projekt.Models
{
    [Table(name: "Biljka")]
    public class Slika
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_slika")]
        public int Id_slika { get; set; }
        [Column("Naziv_slike")]
        public string Naziv_slike { get; set; }
        [Column("Opis_slike")]
        public string Opis_slike { get; set; }
        [Column("Slika1")]
        public Blob Slika1 { get; set; }
        [Column("Id_biljka")]
        public virtual Biljka Id_biljka { get; set; }
    }
}
