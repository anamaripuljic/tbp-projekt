using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class PodsjetnikModel : PageModel
    {
        private readonly ILogger<PodsjetnikModel> _logger;
        private readonly APPDBContext _context;
        [BindProperty]
        public List<Biljka> Biljke { get; set; }
        [BindProperty]
        public List<Dogadaji> Dogadaji { get; set; }
        
        public List<Podsjetnik> Podsjetnici { get; set; }
        private readonly PrijavljeniKorisnik korisnikLogin;
        public List<PodsjetnikBiljka> KorisnikoviPodsjetnici { get; set; }

        public PodsjetnikModel(ILogger<PodsjetnikModel> logger, APPDBContext context, PrijavljeniKorisnik _korisnikLogin)
        {
            _logger = logger;
            _context = context;
            Biljke = _context.Biljke.ToList<Biljka>();
            Podsjetnici = _context.Podsjetnici.ToList<Podsjetnik>();
            korisnikLogin = _korisnikLogin;

        }
        public void OnGet()
        {

            KorisnikoviPodsjetnici = DohvatiPodjetnike();
        }

        public List<PodsjetnikBiljka> DohvatiPodjetnike()
        {
            DateOnly sedamDanaUnazad = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));
            List<PodsjetnikBiljka> podsjetniciBiljaka = new List<PodsjetnikBiljka>();
            var podsjetnici = (from p in _context.Podsjetnici
                               join b in _context.Biljke on p.Id_biljka equals b.Id_biljka
                               where b.Id_korisnik == korisnikLogin.Id && p.Datum > sedamDanaUnazad
                               select new
                               {
                                   vrsta = b.Vrsta,
                                   opis = p.Opis,
                                   datum_podsjetnika = p.Datum
                               }).ToList();
            foreach (var podsjetnik in podsjetnici)
            {
                PodsjetnikBiljka noviPodsjetnik = new PodsjetnikBiljka();
                noviPodsjetnik.VrstaBiljke = podsjetnik.vrsta;
                noviPodsjetnik.Opis = podsjetnik.opis;
                noviPodsjetnik.Datum = podsjetnik.datum_podsjetnika;
                podsjetniciBiljaka.Add(noviPodsjetnik);
            }
            return podsjetniciBiljaka;
        }
    }
}
