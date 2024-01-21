using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using tbp_projekt.Models;
using tbp_projekt.Pages;

namespace tbp_projekt
{
    public class APPDBContext : DbContext
    {
        public APPDBContext(DbContextOptions<APPDBContext> options): base(options) 
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<BiljkaDogadaj>().HasKey(bd => new { bd.Id_biljka, bd.Id_dogadaj });
            modelBuilder.Entity<PovijestDogadajaBiljke>().HasKey(bd => new { bd.Id_biljka, bd.Id_dogadaj, bd.Datum_dogadaja_pov});
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=admin;Database=projekt_tbp");

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Biljka> Biljke { get; set;}
        public DbSet<PovijestMjerenjaBiljke> PodaciEvidencija { get; set; }

        public DbSet<BiljkaDogadaj> BiljkeDogadaji { get; set; }
        public DbSet<Dogadaji> Dogadaji { get; set; }
        public DbSet<PovijestDogadajaBiljke> PovijestiDogadaja { get; set; }
        public DbSet <Podsjetnik> Podsjetnici { get; set; }
        public DbSet <Biljka> Korisnikove_biljke { get; set; }
        

    }
}
