using Microsoft.AspNetCore.Mvc;
using RestaurantSiteComenzi.Models;

namespace RestaurantSiteComenzi.Helpers
{
    public class ProductHelper : Controller
    {
        public Uri uri = new Uri("https://localhost:44305/api/");
        public ViewResult Index(string sortOrder)
        {
            //apelare webservice
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;

                var responseTask = client.GetAsync("Produse?sortOrder=" + sortOrder);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Produs[]>();
                    readTask.Wait();

                    var produse = readTask.Result;

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
