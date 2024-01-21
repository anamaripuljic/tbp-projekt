using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class EvidencijaMjerenjaModel : PageModel
    {
        
        private readonly ILogger<EvidencijaMjerenjaModel> _logger;
        private readonly APPDBContext _context;
        private readonly PrijavljeniKorisnik korisnikLogin;
        [BindProperty]
        public PovijestMjerenjaBiljke PodaciEvidencija1 {  get; set; }
        public List<PovijestMjerenjaBiljke> PodaciEvidencija { get; set;}
        [BindProperty]
        public Biljka Biljka { get; set; } = new Biljka();

        public EvidencijaMjerenjaModel(ILogger<EvidencijaMjerenjaModel> logger, APPDBContext context, PrijavljeniKorisnik korisnikLogin)
        {
            _logger = logger;
            _context = context;
            this.korisnikLogin = korisnikLogin;
        }

        public void OnGet(int id)
        {
            Biljka = _context.Biljke.Where(x => x.Id_biljka == id).FirstOrDefault();
           
        }

        public void OnPost(int id)
        {

            PodaciEvidencija1.Id_biljka = id;
                _context.PodaciEvidencija.Add(PodaciEvidencija1);

                _context.SaveChanges();
                RedirectToPage("MojeBiljke");
            
        }
    }
}
