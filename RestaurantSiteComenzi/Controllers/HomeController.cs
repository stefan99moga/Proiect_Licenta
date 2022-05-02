using Microsoft.AspNetCore.Mvc;
using RestaurantSiteComenzi.Models;
using RestaurantSiteComenzi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace RestaurantSiteComenzi.Controllers
{
    public class HomeController : Controller
    {
        //private readonly RestaurantContext _context;

        //public HomeController(RestaurantContext context)
        //{
        //    _context = context;
        //}

        // GET: Produs
        public ViewResult Index(string sortOrder)
        {
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;


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
