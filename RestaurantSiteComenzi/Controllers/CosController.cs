using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RestaurantSiteComenzi.Models
{
    [Authorize]
    public class CosController : Controller
    {
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

                    if (produse.Length == 0)
                    {
                        return View("EmptyCart");
                    }

                    return View(produse.Where(x => x.Produs.Is_Deprecated == false));
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
