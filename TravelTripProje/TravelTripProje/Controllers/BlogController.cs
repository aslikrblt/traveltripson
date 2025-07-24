using Microsoft.AspNetCore.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        private readonly Context _context;

        // Constructor
        public BlogController(Context context)
        {
            _context = context;
        }
        BlogYorum by = new BlogYorum();
        public IActionResult Index()
        {
            // Veriyi çekmek
          //var blogs = _context.Blogs.ToList();
            by.Deger1 = _context.Blogs.ToList();
            // by.Deger3 = _context.Blogs.Take(3).ToList();
            by.Deger3 = _context.Blogs.OrderByDescending(y => y.ID).Take(3).ToList();
            return View(by);
        }
        
        public IActionResult BlogDetay(int id)
        {
         // var blogbul = _context.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = _context.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = _context.Yorumlars.Where(x => x.BlogID == id).ToList();
            
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {

            ViewData["BlogID"] = id;    
            return PartialView();
            //var deger = _context.Blogs.Where(x => x.ID == id).ToList();
            //ViewBag.deger = _context.Blogs.Where(x => x.ID == id);
            //return PartialView(deger);
        }

        //[HttpPost]
        //public PartialViewResult YorumYap(Yorumlar y)
        //{
        //    _context.Yorumlars.Add(y);
        //    _context.SaveChanges();
        //    return PartialView();
        //}
        [HttpPost]
        public IActionResult YorumYap(Yorumlar y)
        {
            
            _context.Yorumlars.Add(y);
            _context.SaveChanges();

            return RedirectToAction("BlogDetay", new { id = y.BlogID }); // formdan gelen blog ID ile detay sayfasına dön
        }

    }

}
