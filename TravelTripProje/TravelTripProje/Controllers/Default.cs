using Microsoft.AspNetCore.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class Default : Controller
    {
        private readonly Context _context;

        // Constructor
        public Default(Context context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var degerler = _context.Blogs.ToList();
            return View(degerler);
        }
        public IActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var deger1 = _context.Blogs.OrderByDescending(x => x.ID).Take(4).ToList();
            return PartialView(deger1);
            
        }
        public PartialViewResult Partial2()
        {
            var deger2 = _context.Blogs.Take(10).ToList();
            return PartialView(deger2);
            
        }
        public PartialViewResult Partial3()
        {
            var deger3 = _context.Blogs.ToList();
            return PartialView(deger3);

        }
        public PartialViewResult Partial4()
        {
            var deger4 = _context.Blogs.OrderByDescending(x => x.ID).Skip(3).Take(3).ToList();

            return PartialView(deger4);

        }
        
    }
}
