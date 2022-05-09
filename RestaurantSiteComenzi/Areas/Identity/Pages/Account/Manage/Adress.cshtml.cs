using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantSiteComenzi.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace RestaurantSiteComenzi.Areas.Identity.Pages.Account.Manage
{
    public class AdressModel : PageModel
    {
        private readonly RestaurantContext _context;

        public AdressModel(RestaurantContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Adrese> AdreseList { get; set; }

        [BindProperty]
        public  Adrese Adrese { get; set; }

        public void OnGet()
        {
            var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            AdreseList = (from adresa in this._context.Adrese where adresa.User_ID == user_id && adresa.IsDeprecated == false select adresa).ToList();
        }

        public ActionResult OnPost()
        {
            var adrese = Adrese;
            adrese.IsDeprecated = false;
            adrese.Id = 0;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            adrese.User_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Add(adrese);
            _context.SaveChanges();
            
            return RedirectToPage("./Adress");
        }

        public void OnGetEdit(int? id)
        {
            if(id != null)
            {
                var data = (from adress in _context.Adrese
                            where adress.Id == id
                            select adress).SingleOrDefault();
                Adrese = data;
            }
        }

        public ActionResult OnPostEdit()
        {
            var adrese = Adrese;
            adrese.IsDeprecated = true;
            _context.Entry(adrese).Property(x => x.IsDeprecated).IsModified = true;
            _context.SaveChanges();
            return OnPost();
        }

        public ActionResult OnGetDelete(int? id)
        {
            if(id != null)
            {
                var data = (from adress in _context.Adrese
                            where adress.Id == id select adress).SingleOrDefault();
                data.IsDeprecated = true;
                _context.Entry(data).Property(x => x.IsDeprecated).IsModified = true;
                _context.SaveChanges();
            }

            return RedirectToPage("./Adress");
        }

    }
}