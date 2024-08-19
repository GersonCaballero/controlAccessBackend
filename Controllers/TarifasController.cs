using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlAccess.Data;
using ControlAccess.Models;

namespace ControlAccess.Controllers
{
    public class TarifasController : Controller
    {
        private readonly ControlAccessContext _context;

        public TarifasController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Tarifas
        public async Task<IActionResult> Index()
        {
            var controlAccessContext = _context.Tarifas.Include(t => t.Inmuebles);
            return View(await controlAccessContext.ToListAsync());
        }

        // GET: Tarifas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifas = await _context.Tarifas
                .Include(t => t.Inmuebles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarifas == null)
            {
                return NotFound();
            }

            return View(tarifas);
        }

        // GET: Tarifas/Create
        public IActionResult Create()
        {
            ViewData["IdTipoInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy");
            return View();
        }

        // POST: Tarifas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTipoInmueble,Monto,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Tarifas tarifas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy", tarifas.IdTipoInmueble);
            return View(tarifas);
        }

        // GET: Tarifas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifas = await _context.Tarifas.FindAsync(id);
            if (tarifas == null)
            {
                return NotFound();
            }
            ViewData["IdTipoInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy", tarifas.IdTipoInmueble);
            return View(tarifas);
        }

        // POST: Tarifas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipoInmueble,Monto,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Tarifas tarifas)
        {
            if (id != tarifas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifasExists(tarifas.Id))
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
            ViewData["IdTipoInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy", tarifas.IdTipoInmueble);
            return View(tarifas);
        }

        // GET: Tarifas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifas = await _context.Tarifas
                .Include(t => t.Inmuebles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarifas == null)
            {
                return NotFound();
            }

            return View(tarifas);
        }

        // POST: Tarifas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarifas = await _context.Tarifas.FindAsync(id);
            if (tarifas != null)
            {
                _context.Tarifas.Remove(tarifas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifasExists(int id)
        {
            return _context.Tarifas.Any(e => e.Id == id);
        }
    }
}
