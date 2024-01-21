using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class MojeBiljkeModel : PageModel
    {
        private readonly ILogger<MojeBiljkeModel> _logger;
        private readonly APPDBContext _context;
        public PrijavljeniKorisnik korisnikLogin { get; set; }

        [BindProperty]
        public int IdBiljka { get; set; }
        [BindProperty]
        public List<Biljka> Korisnikove_biljke { get; set; }
        public MojeBiljkeModel(ILogger<MojeBiljkeModel> logger, APPDBContext context, PrijavljeniKorisnik _korisnikLogin)
        {
            _logger = logger;
            _context = context;
            korisnikLogin = _korisnikLogin;
            Korisnikove_biljke = _context.Korisnikove_biljke.Where(biljka => biljka.Id_korisnik == korisnikLogin.Id).ToList<Biljka>();

        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(string evidencija, string obaveze)
        {
            if(!string.IsNullOrEmpty(evidencija))
            {
               return RedirectToPage("EvidencijaMjerenja", new {id = IdBiljka});
            }
            if(obaveze != null)
            {
                return RedirectToPage("BiljkaDogadaj", new { id = IdBiljka });
            }
          
            return Page();
        }

    }
}
