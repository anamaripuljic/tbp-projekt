using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbp_projekt.Models
{
    [Table(name: "Povijest_mjerenja_biljke")]
    public class PovijestMjerenjaBiljke
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_podaci")]
        public int Id_podaci { get; set; }
        [Column("Datum")]
        public DateOnly Datum { get; set; }
        [Column("Vlaznost_zraka")]
        public int Vlaznost_zraka { get; set; }
        [Column("Intezitet_svjetla")]
        public string Intezitet_svjetla { get; set; }
        [Column("Temperatura")]
        public int Temperatura { get; set; }
        [Column("Velicina_biljke")]
        public string Velicina_biljke { get; set; }
        [Column("Id_biljka")]
        public virtual int Id_biljka { get; set; }
    }
}
