using Microsoft.AspNetCore.Mvc;
using RestaurantSiteComenzi.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantSiteComenzi.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantContext _context;

        public HomeController(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync(string sortOrder)
        {
            ViewData["PizzaParam"] = String.IsNullOrEmpty(sortOrder) ? "pizza": "pizza";
            ViewData["DesertParam"] = String.IsNullOrEmpty(sortOrder) ? "desert" : "desert";
            ViewData["BauturaParam"] = String.IsNullOrEmpty(sortOrder) ? "bautura" : "bautura";

            var produse = from p in _context.Produs select p;
            int pizza = 1;
            int desert = 2;
            int bautura = 3;

            switch (sortOrder)
            {
                case "pizza":
                    produse = produse.Where(x => x.Categorie_Id == pizza);
                    break;
                case "desert":
                    produse = produse.Where(x => x.Categorie_Id == desert);
                    break;
                case "bautura":
                    produse = produse.Where(x => x.Categorie_Id == bautura);
                    break;
                default:
                    produse = produse.OrderBy(x => x.Categorie_Id);
                    break;
            }

            return View(await produse.AsNoTracking().ToListAsync());
        }
    }
}
