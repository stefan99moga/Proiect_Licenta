using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantSiteComenzi.Models;
using System.Security.Claims;

namespace RestaurantSiteComenzi.Areas.Identity.Pages.Account.Manage
{
    public class CreateNewAdressModel : PageModel
    {
        private readonly RestaurantContext _context;

        public CreateNewAdressModel(RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Adrese> AdreseList { get; set; }

        [BindProperty]
        public Adrese Adrese { get; set; }


        public ActionResult OnPost()
        {
            var adrese = Adrese;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            adrese.User_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Add(adrese);
            _context.SaveChanges();

            return Redirect("~/Checkout");
        }

    }
}
