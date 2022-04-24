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

            AdreseList = (from adresa in this._context.Adrese where adresa.User_ID == user_id select adresa).ToList();
        }

        public ActionResult OnPost()
        {
            var adrese = Adrese;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            adrese.User_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _context.Add(adrese);
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entry(adrese).Property(x => x.Oras).IsModified = true;
            _context.Entry(adrese).Property(x => x.Strada).IsModified = true;
            _context.Entry(adrese).Property(x => x.Numar).IsModified = true;
            _context.Entry(adrese).Property(x => x.Bloc).IsModified = true;
            _context.Entry(adrese).Property(x => x.Scara).IsModified = true;
            _context.Entry(adrese).Property(x => x.Apartament).IsModified = true;
            _context.SaveChanges();
            return RedirectToPage("./Adress");
        }

        public ActionResult OnGetDelete(int? id)
        {
            if(id != null)
            {
                var data = (from adress in _context.Adrese
                            where adress.Id == id select adress).SingleOrDefault();
                _context.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToPage("./Adress");
        }

    }
}