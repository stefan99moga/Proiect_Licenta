using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RestaurantSiteComenzi.Models
{
    [Authorize]
    public class CosController : Controller
    {
        private readonly RestaurantContext _context;
        public CosController(RestaurantContext context)
        {
            _context = context;
        }

        public Uri uri = new Uri("https://localhost:44305/api/");

        public ViewResult Index()
        {
            //apelare webservice
            using (var client = new HttpClient())
            {
                var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                client.BaseAddress = uri;
                var responseTask = client.GetAsync("Cart?user_id=" + user_id);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Cos[]>();
                    readTask.Wait();

                    var produse = readTask.Result;
                    
                    //double x = produse.FirstOrDefault().Quantity;
                    //double y = (double)produse.FirstOrDefault().Produs.Pret_Produs;
                    //ViewData["pret_double"] = y;
                    //ViewData["Calcul_total"] = x * y;


                    if (produse.Length == 0)
                    {
                        return View("EmptyCart");
                    }

                    return View(produse);
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
