using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSiteComenzi.Models;
using System.Security.Claims;

namespace RestaurantSiteComenzi.Controllers
{
    [Authorize]
    public class ComenziController : Controller
    {
        public Uri uri = new Uri("https://localhost:44305/api/");

        private readonly RestaurantContext _context;

        public ComenziController(RestaurantContext context)
        {
            _context = context;
        }

        public ViewResult Index(string sortOrder)
        {
            //Sortare dupa stare comanda
            ViewData["IndecisaParam"] = String.IsNullOrEmpty(sortOrder) ? "indecisa" : "indecisa";
            ViewData["PrimitaParam"] = String.IsNullOrEmpty(sortOrder) ? "primita" : "primita";
            ViewData["ConfirmataParam"] = String.IsNullOrEmpty(sortOrder) ? "confirmata" : "confirmata";
            ViewData["RefuzataParam"] = String.IsNullOrEmpty(sortOrder) ? "refuzata" : "refuzata";
            ViewData["AnulataParam"] = String.IsNullOrEmpty(sortOrder) ? "anulata" : "anulata";
            ViewData["LivrataParam"] = String.IsNullOrEmpty(sortOrder) ? "livrata" : "livrata";


            //apelare webservice
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var responseTask = client.GetAsync("Comenzi?sortOrder=" + sortOrder);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Comenzi[]>();
                    readTask.Wait();

                    var comenzi = readTask.Result;

                    if (comenzi.Length == 0)
                    {
                        return View("EmptyOrders");
                    }

                    return View(comenzi.OrderBy(x => x.Stare_Comanda_ID));
                }
                else
                {
                    return View();
                }
            }
        }

        public ViewResult Edit(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var responseTask = client.GetAsync("Comenzi/" + id);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Comenzi>();
                    readTask.Wait();

                    var comenzi = readTask.Result;

                    return View(comenzi);
                }
                else
                {
                    return View();
                }
            }

        }

        public ActionResult GetStareComanda()
        {
            var order_states = _context.Stare_Comanda.Select(a => new
            {
                a.Id,
                a.Nume
            });

            return Json(order_states.ToList());
        }


        public ViewResult Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var responseTask = client.GetAsync("Cart/GetComandaDetails?comandaId=" + id);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Cos[]>();
                    readTask.Wait();

                    var comenzi = readTask.Result;

                    return View(comenzi);
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
