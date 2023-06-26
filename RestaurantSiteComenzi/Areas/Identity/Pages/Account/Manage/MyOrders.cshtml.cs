using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantSiteComenzi.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace RestaurantSiteComenzi.Areas.Identity.Pages.Account.Manage
{
    public class MyOrdersModel : PageModel
    {
        private readonly RestaurantContext _context;

        public MyOrdersModel(RestaurantContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Comenzi> ComenziList { get; set; }

        [BindProperty]
        public  Comenzi Comenzi { get; set; }

        public void OnGet()
        {
            var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ComenziList = (from comanda in this._context.Comenzi where comanda.User_ID == user_id && comanda.Stare_Comanda_ID != 0 select comanda)
                .Include(x => x.Adrese)
                .Include(x => x.Stare_Comanda)
                .Include(x => x.Tip_plata)
                .OrderByDescending(x => x.Data_Comanda)
                .ToList();
        }

    }
}