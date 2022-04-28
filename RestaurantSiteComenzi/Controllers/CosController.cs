using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {

            var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var items = _context.Articol_Cos.Where(x => x.User_id == user_id);

            if (items.Any())
            {
                return View(await _context.Articol_Cos.Include(x => x.Produs).ToListAsync());
            }else
            {
                return View("EmptyCart");
            }
        }
    }
}
