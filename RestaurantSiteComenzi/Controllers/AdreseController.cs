using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestaurantSiteComenzi.Models
{
    public class AdreseController : Controller
    {
        private readonly RestaurantContext _context;

        public AdreseController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Adrese
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adrese.ToListAsync());
        }

        // GET: Adrese/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adrese = await _context.Adrese
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adrese == null)
            {
                return NotFound();
            }

            return View(adrese);
        }

        // GET: Adrese/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adrese/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User_ID,Oras,Strada,Numar,Bloc,Scara,Apartament")] Adrese adrese)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adrese);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adrese);
        }

        // GET: Adrese/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adrese = await _context.Adrese.FindAsync(id);
            if (adrese == null)
            {
                return NotFound();
            }
            return View(adrese);
        }

        // POST: Adrese/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User_ID,Oras,Strada,Numar,Bloc,Scara,Apartament")] Adrese adrese)
        {
            if (id != adrese.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adrese);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdreseExists(adrese.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adrese);
        }

        // GET: Adrese/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adrese = await _context.Adrese
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adrese == null)
            {
                return NotFound();
            }

            return View(adrese);
        }

        // POST: Adrese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adrese = await _context.Adrese.FindAsync(id);
            _context.Adrese.Remove(adrese);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdreseExists(int id)
        {
            return _context.Adrese.Any(e => e.Id == id);
        }
    }
}
