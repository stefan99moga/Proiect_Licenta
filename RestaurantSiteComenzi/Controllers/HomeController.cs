using Microsoft.AspNetCore.Mvc;
using RestaurantSiteComenzi.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantSiteComenzi.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantContext _context;

        public HomeController(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Produs.ToListAsync());
        }
    }
}
