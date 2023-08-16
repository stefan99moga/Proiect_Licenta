using Microsoft.AspNetCore.Mvc;
using RestaurantSiteComenzi.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantSiteComenzi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Produs
        public ViewResult Index(string sortOrder)
        {
            
            //Sortare dupa categorie produs
            ViewData["PizzaParam"] = String.IsNullOrEmpty(sortOrder) ? "pizza" : "pizza";
            ViewData["DesertParam"] = String.IsNullOrEmpty(sortOrder) ? "desert" : "desert";
            ViewData["BauturaParam"] = String.IsNullOrEmpty(sortOrder) ? "bautura" : "bautura";

            ProductHelper productHelper = new();

            var result = productHelper.Index(sortOrder).Model;

            return View(result);
        }
    }
}
