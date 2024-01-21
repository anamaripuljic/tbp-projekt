using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbp_projekt.Models
{
    [Table(name: "Biljka")]
    public class Biljka
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_biljka")]
        public int Id_biljka { get; set; }
        [Column("Datum_sadnje")]
        public DateOnly Datum_sadnje { get; set; }
        [Column("Lokacija_staniste")]
        public string? Lokacija_staniste { get; set; }
        [Column("Opis")]
        public string? Opis { get; set; }
        [Column("Velicina_biljke")]
        public string? Velicina_biljke { get; set; }
        [Column("Temperatura")]
        public string? Temperatura { get; set; }
        [Column("Vlaznost_zraka")]
        public string? Vlaznost_zraka { get; set; }
        [Column("Intezitet_svjetla")]
        public string? Intezitet_svjetla { get; set; }
        [Column("Ucestalost_zalijevanja")]
        public string? Ucestalost_zalijevanja { get; set; }
        [Column("Razdoblje_cvata")]
        public string? Razdoblje_cvata { get; set; }
        [Column("Razdoblje_gnojidbe")]
        public string? Razdoblje_gnojidbe { get; set; }
        [Column("Zemljiste")]
        public string? Zemljiste { get; set; }
        [Column("Vrsta_posude")]
        public string? Vrsta_posude { get; set; }
        [Column("Vrsta")]
        public string? Vrsta { get; set; }
        [Column("Id_korisnik")]
        public virtual int Id_korisnik { get; set; }
    }

}
