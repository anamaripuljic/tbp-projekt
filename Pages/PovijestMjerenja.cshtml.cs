using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using tbp_projekt.Models;

namespace tbp_projekt.Pages
{
    public class PovijestMjerenjaModel : PageModel
    {
        private readonly ILogger<PovijestMjerenjaModel> _logger;
        private readonly APPDBContext _context;
        [BindProperty]
        public List<Biljka> Biljke { get; set; }

        public PovijestMjerenjaModel(ILogger<PovijestMjerenjaModel> logger, APPDBContext context)
        {
            _logger = logger;
            _context = context;
            Biljke = _context.Biljke.ToList<Biljka>();
        }
        public void OnGet()
        {
        }
    }
}
