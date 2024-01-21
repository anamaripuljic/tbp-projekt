using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class PovijestDogadajaModel : PageModel
    {
        private readonly ILogger<PovijestDogadajaModel> _logger;
        private readonly APPDBContext _context;

        public List<Biljka> Biljke { get; set; }
        public List<Dogadaji> Dogadaji {  get; set; }

        public List<SelectListItem> BiljkeZaOdabir { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> DogadajZaOdabir { get; set; } = new List<SelectListItem>();
        public List<PovijestDogadajaBiljke> PovijestiDogadaja {  get; set; }

        [BindProperty]
        public PovijestDogadajaBiljke kreiraniDogadaji { get; set; }
        public PrijavljeniKorisnik korisnik { get; set; }
        [BindProperty]
        public List<Biljka> Korisnikove_biljke { get; set; }


        public PovijestDogadajaModel(ILogger<PovijestDogadajaModel> logger, APPDBContext context, PrijavljeniKorisnik korisnik)
        {
            _logger = logger;
            _context = context;
            Biljke = _context.Biljke.ToList<Biljka>();
            Dogadaji = _context.Dogadaji.ToList<Dogadaji>();
            PovijestiDogadaja = _context.PovijestiDogadaja.ToList<PovijestDogadajaBiljke>();
            this.korisnik = korisnik;
            Korisnikove_biljke = _context.Korisnikove_biljke.Where(biljka => biljka.Id_korisnik == korisnik.Id).ToList<Biljka>();
            foreach (var item in Korisnikove_biljke)
            {
                var nova = new SelectListItem(item.Vrsta, item.Id_biljka.ToString());
                BiljkeZaOdabir.Add(nova);
            }
        }
        public void OnGet()
        {
           
            foreach (var item in Dogadaji)
            {
                var novi = new SelectListItem(item.Naziv_dogadaja, item.Id_dogadaj.ToString());
                DogadajZaOdabir.Add(novi);
            }
        }
        public void OnPost()
        {
            _context.PovijestiDogadaja.Add(kreiraniDogadaji);

            _context.SaveChanges();
            OnGet();
        }
    }
}
