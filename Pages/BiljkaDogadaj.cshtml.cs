using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class BiljkaDogadajModel : PageModel
    {
        private readonly ILogger<BiljkaDogadajModel> _logger;
        private readonly APPDBContext _context;
   
        public List<Dogadaji> Dogadaji { get; set; }

        public List<BiljkaDogadaj> BiljkeDogadaji { get; set; }

        public List<SelectListItem> DogadajZaOdabir { get; set; } = new List<SelectListItem>();
        

        [BindProperty]
        public int IdDogadaj { get; set; }
        [BindProperty]
        public int Ucestalost { get; set; }

        [BindProperty]
        public Biljka Biljka { get; set; } = new Biljka();

        public BiljkaDogadajModel(ILogger<BiljkaDogadajModel> logger, APPDBContext context)
        {
            _logger = logger;
            _context = context;
            Dogadaji = _context.Dogadaji.ToList<Dogadaji>();
            BiljkeDogadaji = _context.BiljkeDogadaji.ToList<BiljkaDogadaj>();
            
        }
        public void OnGet(int id)
        {
            Biljka = _context.Biljke.Where(x => x.Id_biljka == id).FirstOrDefault();
            foreach (var item in Dogadaji)
            {
                var novi = new SelectListItem(item.Naziv_dogadaja, item.Id_dogadaj.ToString());
                DogadajZaOdabir.Add(novi);
            }
        }

        public void OnPost(int id)
        {
        
           BiljkaDogadaj novaBiljkaDogadaj = new BiljkaDogadaj();
           novaBiljkaDogadaj.Id_biljka = id;
           novaBiljkaDogadaj.Id_dogadaj = IdDogadaj;
           novaBiljkaDogadaj.Ucestalost_u_danima = Ucestalost;
           _context.BiljkeDogadaji.Add(novaBiljkaDogadaj);

            _context.SaveChanges();
           
        }
    }
}
