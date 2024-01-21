using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbp_projekt.Models
{
    [Table(name: "Korisnik")]
    public class Korisnik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_korisnik")]   
        public int Id_korisnik { get; set; }
        [Column("Ime")]
        public string Ime { get; set; }
        [Column("Prezime")]
        public string Prezime { get; set; }
        [Column("Kor_ime")]
        public string Kor_ime { get; set; }
        [Column("Lozinka")]
        public string Lozinka { get; set; }
        [Column("Email")]
        public string  Email { get; set; }
       

    }
}
