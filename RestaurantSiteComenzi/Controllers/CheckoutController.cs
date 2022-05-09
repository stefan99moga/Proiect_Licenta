using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantSiteComenzi.Models;
using System.Security.Claims;

namespace RestaurantSiteComenzi.Controllers
{
    public class CheckoutController : Controller
    {
        public Uri uri = new Uri("https://localhost:44305/api/");

        private readonly RestaurantContext _context;

        public CheckoutController(RestaurantContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAdresses()
        {
            var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var adrese = from a in _context.Adrese.Where(a => a.User_ID == user_id && a.IsDeprecated == false) select a;
            adrese.Select(a => new
            {
                a.Id,
                a.Oras,
                a.Strada,
                a.Numar,
                a.Bloc,
                a.Scara,
                a.Apartament
            });

            return Json(adrese.ToList());
        }

        [HttpGet]
        public ActionResult GetTipPlata()
        {
            var metode_plata =
            _context.Tip_Plata.Select(a => new
            {
                a.Id,
                a.Tipul_Platii
            });

            return Json(metode_plata.ToList());
        }

        public ActionResult CheckOrder()
        {
            return View("Verificare");
        }

        public ActionResult OrderSent()
        {
            return View("OrderSent");
        }
    }
}
