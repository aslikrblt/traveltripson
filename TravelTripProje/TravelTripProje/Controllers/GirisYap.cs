using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class GirisYap : Controller
    {
        private readonly Context _context;

        // Constructor
        public GirisYap(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl = null) // returnUrl parametresi eklendi
        {
            ViewData["ReturnUrl"] = returnUrl; // ViewData'ya returnUrl eklendi
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Adminsınıf ad, string? returnUrl = null)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ad.Kullanici),
                    new Claim(ClaimTypes.Role, bilgiler.Rol) // Rol bilgisini Claims'e ekliyoruz
                };



                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Eğer returnUrl varsa oraya yönlendir, yoksa Admin paneline git
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                // Default olarak Admin paneline yönlendir
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "GirisYap");
        }
    }
}
