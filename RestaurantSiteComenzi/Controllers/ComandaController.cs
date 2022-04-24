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
    public class ComandaController : Controller
    {
        private readonly RestaurantContext _context;

        public ComandaController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Comanda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comanda_Livrare.Include( x=> x.Stare_Comanda).ToListAsync());
        }

        // GET: Comanda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComanda = await _context.Comanda_Livrare
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblComanda == null)
            {
                return NotFound();
            }

            return View(tblComanda);
        }

        // GET: Comanda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comanda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nume,Prenume,Oras,Strada,Numar,Bloc,Scara,Apartament,Numar_Telefon, Stare_Comanda_ID")] ComandaLivrare tblComanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblComanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblComanda);
        }

        // GET: Comanda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComanda = await _context.Comanda_Livrare.FindAsync(id);
            if (tblComanda == null)
            {
                return NotFound();
            }
            return View(tblComanda);
        }

        // POST: Comanda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("id,Nume,Prenume,Oras,Strada,Numar,Bloc,Scara,Apartament,Numar_Telefon, Stare_Comanda_ID")] ComandaLivrare tblComanda)
        //{
        //    if (id != tblComanda.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tblComanda);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!tblComandaExists(tblComanda.id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tblComanda);
        //}

        // GET: Comanda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComanda = await _context.Comanda_Livrare
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblComanda == null)
            {
                return NotFound();
            }

            return View(tblComanda);
        }

        // POST: Comanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblComanda = await _context.Comanda_Livrare.FindAsync(id);
            _context.Comanda_Livrare.Remove(tblComanda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblComandaExists(int id)
        {
            return _context.Comanda_Livrare.Any(e => e.id == id);
        }
    }
}
