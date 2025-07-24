using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için bu gerekli
using TravelTripProje.Attributes;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    [Authorize] // 👈 Tüm controller korumaya alınır
    public class Admin : Controller
    {
        private readonly Context _context;

        // Constructor
        public Admin(Context context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var degerler = _context.Blogs.ToList();
            return View(degerler);
        }

        // Sadece UltraAdmin erişebilir
        [UltraAdminAuthorize]
        [HttpGet]
        public IActionResult YeniBlog()
        {
            return View();
        }

        // Sadece UltraAdmin erişebilir
        [UltraAdminAuthorize]
        [HttpPost]
        public IActionResult YeniBlog(Blog p)
        {
            _context.Blogs.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Sadece UltraAdmin erişebilir
        [UltraAdminAuthorize]
        public IActionResult BlogSil(int id)
        {
            var b=_context.Blogs.Find(id);
            _context.Blogs.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Sadece UltraAdmin erişebilir
        [UltraAdminAuthorize]
        public IActionResult BlogGetir(int id)
        {
            var bl=_context.Blogs.Find(id);    
            return View("BlogGetir", bl);
        }

        // Sadece UltraAdmin erişebilir
        [UltraAdminAuthorize]
        public IActionResult BlogGuncelle(Blog b)
        {
            var blg=_context.Blogs.Find(b.ID);    
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Hem Admin hem UltraAdmin erişebilir
        public IActionResult YorumListesi()
        {
            var yorumlar = _context.Yorumlars.Include(y => y.Blog).ToList();
            return View(yorumlar);
        }

        // Hem Admin hem UltraAdmin erişebilir
        public IActionResult YorumSil(int id)
        {
            var b = _context.Yorumlars.Find(id);
            _context.Yorumlars.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        // Hem Admin hem UltraAdmin erişebilir
        public IActionResult YorumGetir(int id)
        {
            var bl = _context.Yorumlars.Find(id);
            return View("YorumGetir", bl);
        }

        // Hem Admin hem UltraAdmin erişebilir
        public IActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = _context.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            _context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        // Yardımcı method - kullanıcının rolünü kontrol etmek için
        private bool IsUltraAdmin()
        {
            return User.FindFirst(ClaimTypes.Role)?.Value == "UltraAdmin";
        }
    }
}
