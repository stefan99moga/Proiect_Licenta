using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSiteComenzi.Models;

namespace RestaurantSiteComenzi.Controllers
{
    [Authorize]
    public class ProdusController : Controller
    {
        private readonly RestaurantContext _context;

        public ProdusController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Produs
        public async Task<IActionResult> Index(string sortOrder)
        {
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            //Sortare dupa categorie produs
            ViewData["PizzaParam"] = String.IsNullOrEmpty(sortOrder) ? "pizza" : "pizza";
            ViewData["DesertParam"] = String.IsNullOrEmpty(sortOrder) ? "desert" : "desert";
            ViewData["BauturaParam"] = String.IsNullOrEmpty(sortOrder) ? "bautura" : "bautura";
            //Sortare dupa nume
            ViewData["NameParam"] = sortOrder == "nume_cresc" ? "nume_desc" : "nume_cresc";
            //Sortare dupa pret
            ViewData["PretParam"] = sortOrder == "pret_cresc" ? "pret_desc" : "pret_cresc";

            var produse = from p in _context.Produs select p;
            int pizza = 1;
            int desert = 2;
            int bautura = 3;


            switch (sortOrder)
            {
                case "pizza":
                    produse = produse.Where(x => x.Categorie_Id == pizza);
                    break;
                case "desert":
                    produse = produse.Where(x => x.Categorie_Id == desert);
                    break;
                case "bautura":
                    produse = produse.Where(x => x.Categorie_Id == bautura);
                    break;
                case "nume_cresc":
                    produse = produse.OrderBy(x => x.Nume_Produs);
                    break;
                case "nume_desc":
                    produse = produse.OrderByDescending(x => x.Nume_Produs);
                    break;
                case "pret_cresc":
                    produse = produse.OrderBy(x => x.Pret_Produs);
                    break;
                case "pret_desc":
                    produse = produse.OrderByDescending(produse => produse.Pret_Produs);
                    break;
                default:
                    produse = produse.OrderBy(x => x.Categorie_Id);
                    break;
            }


            return View(await produse.Include(x => x.Categorie_produs).AsNoTracking().ToListAsync());
        }

        // GET: Produs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs
                .FirstOrDefaultAsync(m => m.id == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // GET: Produs/Create
        public IActionResult Create()
        {
            ViewBag.Categorii_Produs = new SelectList(_context.Categorie_Produs, "id","Categorie");
            return View();
        }

        // POST: Produs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nume_Produs,Pret_Produs,Imagine,Categorie_Id")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produs);
        }

        // GET: Produs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Categorii_Produs = new SelectList(_context.Categorie_Produs, "id", "Categorie");
            var produs = await _context.Produs.FindAsync(id);
            if (produs == null)
            {
                return NotFound();
            }
            return View(produs);
        }

        // POST: Produs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nume_Produs,Pret_Produs,Imagine,Categorie_Id")] Produs produs)
        {
            if (id != produs.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdusExists(produs.id))
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
            return View(produs);
        }

        // GET: Produs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs
                .FirstOrDefaultAsync(m => m.id == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // POST: Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produs = await _context.Produs.FindAsync(id);
            _context.Produs.Remove(produs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.id == id);
        }
    }
}
