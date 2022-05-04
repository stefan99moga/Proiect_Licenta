using Microsoft.AspNetCore.Mvc;
using RestaurantSiteComenzi.Models;
using RestaurantSiteComenzi.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantSiteComenzi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //private readonly RestaurantContext _context;

        //public HomeController(RestaurantContext context)
        //{
        //    _context = context;
        //}

        public Uri uri = new Uri("https://localhost:44305/api/");
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

        //Post Produs to Cos
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Cos cos)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = uri;
        //        var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        cos.User_id = user_id;
        //        var postTask = client.PostAsJsonAsync<Cos>("Cos", cos);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        //    return View(cos);
        //}
    }
}
