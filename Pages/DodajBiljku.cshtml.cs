using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class DodajBiljkuModel : PageModel
    {
        private readonly ILogger<DodajBiljkuModel> _logger;
        private readonly APPDBContext _context;
        [BindProperty]
        public Biljka Biljka1 { get; set; }
        public List<Biljka> Biljke { get; set; }
        private readonly PrijavljeniKorisnik korisnikLogin;

        public Korisnik UlogiraniKorisnik { get; set; }

        public DodajBiljkuModel(ILogger<DodajBiljkuModel> logger, APPDBContext context, PrijavljeniKorisnik korisnikLogin)
        {
            _logger = logger;
            _context = context;
            this.korisnikLogin = korisnikLogin;
        }

        public void OnGet()
        {
            //Biljke = _context.Biljke.ToList<Biljka>();
        }

        public void OnPost()
        {
            Biljka1.Id_korisnik = korisnikLogin.Id;
                _context.Biljke.Add(Biljka1);
                
                _context.SaveChanges();
            
        }
    }
}
