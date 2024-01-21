using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbp_projekt.Models
{
    [Table(name: "Povijest_dogadaja_biljke")]
    public class PovijestDogadajaBiljke
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_biljka")]
        public virtual int Id_biljka { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_dogadaj")]
        public virtual int Id_dogadaj { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Datum_dogadaja_pov")]
        public virtual DateOnly Datum_dogadaja_pov { get; set; }

    }
}
