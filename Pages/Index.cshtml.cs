using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly APPDBContext _context;
        private readonly PrijavljeniKorisnik korisnikLogin;
        [BindProperty]
        public Korisnik Korisnik1 { get; set; }
        public List<Korisnik> Korisnici { get; set; }

        public IndexModel(ILogger<IndexModel> logger, APPDBContext context, PrijavljeniKorisnik _korisnikLogin)
        {
            _logger = logger;
            _context = context;
            Korisnici = _context.Korisnici.ToList<Korisnik>();
            korisnikLogin = _korisnikLogin;
        }

        public void OnGet()
        {
            
        }


        public IActionResult OnPost()
        {
            Console.WriteLine($"Ne postoji korisnik");
            foreach (var k in Korisnici)
            {

                if (Korisnik1.Kor_ime == k.Kor_ime && Korisnik1.Lozinka == k.Lozinka)
                {
                    korisnikLogin.Id = k.Id_korisnik;
                    return RedirectToPage("DodajBiljku");
                }
                
            }
            return Page();
        }

    }
}
