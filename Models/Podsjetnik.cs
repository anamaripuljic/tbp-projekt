using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbp_projekt.Models
{
    [Table(name: "Podsjetnik")]
    public class Podsjetnik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_podsjetnik")]
        public int Id_podsjetnik { get; set; }
        [Column("Opis")]
        public string Opis { get; set; }
        [Column("Datum")]
        public DateOnly? Datum { get; set; }
        [Column("Id_biljka")]
        public virtual int Id_biljka { get; set; }
        [Column("Id_dogadaj")]
        public virtual int Id_dogadaj { get; set; }
    }
}
