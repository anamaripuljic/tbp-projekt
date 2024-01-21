using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbp_projekt.Models
{
    [Table(name: "Biljka_Dogadaj")]
    public class BiljkaDogadaj
    {
        [Column("Id_biljka")]
        public virtual int Id_biljka { get; set; }

        [Column("Id_dogadaj")]
        public virtual int Id_dogadaj { get; set; }

        [Column("Ucestalost_u_danima")]
        public int Ucestalost_u_danima { get; set; }
    }
}
