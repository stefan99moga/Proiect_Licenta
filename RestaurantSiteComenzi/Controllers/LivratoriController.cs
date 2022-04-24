using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSiteComenzi.Models;

namespace RestaurantSiteComenzi.Controllers
{
    [Authorize]
    public class LivratoriController : Controller
    {
        private readonly RestaurantContext _context;

        public LivratoriController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Livrators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livrator.ToListAsync());
        }

        // GET: Livrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livrator = await _context.Livrator
                .FirstOrDefaultAsync(m => m.id == id);
            if (livrator == null)
            {
                return NotFound();
            }

            return View(livrator);
        }

        // GET: Livrators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nume_Livrator,Prenume_Livrator,Telefon_Livrator,Statut_Livrator")] Livrator livrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livrator);
        }

        // GET: Livrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livrator = await _context.Livrator.FindAsync(id);
            if (livrator == null)
            {
                return NotFound();
            }
            return View(livrator);
        }

        // POST: Livrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nume_Livrator,Prenume_Livrator,Telefon_Livrator,Statut_Livrator")] Livrator livrator)
        {
            if (id != livrator.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivratorExists(livrator.id))
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
            return View(livrator);
        }

        // GET: Livrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livrator = await _context.Livrator
                .FirstOrDefaultAsync(m => m.id == id);
            if (livrator == null)
            {
                return NotFound();
            }

            return View(livrator);
        }

        // POST: Livrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livrator = await _context.Livrator.FindAsync(id);
            _context.Livrator.Remove(livrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivratorExists(int id)
        {
            return _context.Livrator.Any(e => e.id == id);
        }
    }
}
