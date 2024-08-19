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
    public class BloquesController : Controller
    {
        private readonly ControlAccessContext _context;

        public BloquesController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Bloques
        public async Task<IActionResult> Index()
        {
            var controlAccessContext = _context.Bloque.Include(b => b.Residencial);
            return View(await controlAccessContext.ToListAsync());
        }

        // GET: Bloques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloque = await _context.Bloque
                .Include(b => b.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloque == null)
            {
                return NotFound();
            }

            return View(bloque);
        }

        // GET: Bloques/Create
        public IActionResult Create()
        {
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            return View();
        }

        // POST: Bloques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,ResidencialId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Bloque bloque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", bloque.ResidencialId);
            return View(bloque);
        }

        // GET: Bloques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloque = await _context.Bloque.FindAsync(id);
            if (bloque == null)
            {
                return NotFound();
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", bloque.ResidencialId);
            return View(bloque);
        }

        // POST: Bloques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,ResidencialId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Bloque bloque)
        {
            if (id != bloque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloqueExists(bloque.Id))
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
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", bloque.ResidencialId);
            return View(bloque);
        }

        // GET: Bloques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloque = await _context.Bloque
                .Include(b => b.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloque == null)
            {
                return NotFound();
            }

            return View(bloque);
        }

        // POST: Bloques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloque = await _context.Bloque.FindAsync(id);
            if (bloque != null)
            {
                _context.Bloque.Remove(bloque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloqueExists(int id)
        {
            return _context.Bloque.Any(e => e.Id == id);
        }
    }
}
