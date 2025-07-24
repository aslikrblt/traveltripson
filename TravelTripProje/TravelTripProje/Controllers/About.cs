using Microsoft.AspNetCore.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class About : Controller
    {
        private readonly Context _context;

        public About(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Hakkimizdas.ToList();
            return View(degerler);
        }
    }
}