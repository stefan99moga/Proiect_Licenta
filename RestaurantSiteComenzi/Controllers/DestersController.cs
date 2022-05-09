using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSiteComenzi.Models;

namespace RestaurantSiteComenzi.Controllers
{
    public class DestersController : Controller
    {
        private readonly RestaurantContext _context;

        public DestersController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Desters
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Comenzi.Include(c => c.Adrese).Include(c => c.Stare_Comanda).Include(c => c.Tip_plata);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Desters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comenzi = await _context.Comenzi
                .Include(c => c.Adrese)
                .Include(c => c.Stare_Comanda)
                .Include(c => c.Tip_plata)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comenzi == null)
            {
                return NotFound();
            }

            return View(comenzi);
        }

        // GET: Desters/Create
        public IActionResult Create()
        {
            ViewData["Adress_ID"] = new SelectList(_context.Adrese, "Id", "Numar");
            ViewData["Stare_Comanda_ID"] = new SelectList(_context.Set<Stare_Comanda>(), "Id", "Id");
            ViewData["Tip_Plata_ID"] = new SelectList(_context.Tip_Plata, "Id", "Tipul_Platii");
            return View();
        }

        // POST: Desters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User_ID,Adress_ID,Tip_Plata_ID,Total_Plata,Data_Comanda,Stare_Comanda_ID,Is_Deprecated")] Comenzi comenzi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comenzi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Adress_ID"] = new SelectList(_context.Adrese, "Id", "Numar", comenzi.Adress_ID);
            ViewData["Stare_Comanda_ID"] = new SelectList(_context.Set<Stare_Comanda>(), "Id", "Id", comenzi.Stare_Comanda_ID);
            ViewData["Tip_Plata_ID"] = new SelectList(_context.Tip_Plata, "Id", "Tipul_Platii", comenzi.Tip_Plata_ID);
            return View(comenzi);
        }

        // GET: Desters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comenzi = await _context.Comenzi.FindAsync(id);
            if (comenzi == null)
            {
                return NotFound();
            }
            ViewData["Adress_ID"] = new SelectList(_context.Adrese, "Id", "Numar", comenzi.Adress_ID);
            ViewData["Stare_Comanda_ID"] = new SelectList(_context.Set<Stare_Comanda>(), "Id", "Id", comenzi.Stare_Comanda_ID);
            ViewData["Tip_Plata_ID"] = new SelectList(_context.Tip_Plata, "Id", "Tipul_Platii", comenzi.Tip_Plata_ID);
            return View(comenzi);
        }

        // POST: Desters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User_ID,Adress_ID,Tip_Plata_ID,Total_Plata,Data_Comanda,Stare_Comanda_ID,Is_Deprecated")] Comenzi comenzi)
        {
            if (id != comenzi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comenzi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComenziExists(comenzi.Id))
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
            ViewData["Adress_ID"] = new SelectList(_context.Adrese, "Id", "Numar", comenzi.Adress_ID);
            ViewData["Stare_Comanda_ID"] = new SelectList(_context.Set<Stare_Comanda>(), "Id", "Id", comenzi.Stare_Comanda_ID);
            ViewData["Tip_Plata_ID"] = new SelectList(_context.Tip_Plata, "Id", "Tipul_Platii", comenzi.Tip_Plata_ID);
            return View(comenzi);
        }

        // GET: Desters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comenzi = await _context.Comenzi
                .Include(c => c.Adrese)
                .Include(c => c.Stare_Comanda)
                .Include(c => c.Tip_plata)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comenzi == null)
            {
                return NotFound();
            }

            return View(comenzi);
        }

        // POST: Desters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comenzi = await _context.Comenzi.FindAsync(id);
            _context.Comenzi.Remove(comenzi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComenziExists(int id)
        {
            return _context.Comenzi.Any(e => e.Id == id);
        }
    }
}
