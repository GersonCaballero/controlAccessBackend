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
    public class Zonas1Controller : Controller
    {
        private readonly ControlAccessContext _context;

        public Zonas1Controller(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Zonas1
        public async Task<IActionResult> Index()
        {
            var controlAccessContext = _context.Zonas.Include(z => z.Residencial);
            return View(await controlAccessContext.ToListAsync());
        }

        // GET: Zonas1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .Include(z => z.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return View(zonas);
        }

        // GET: Zonas1/Create
        public IActionResult Create()
        {
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            return View();
        }

        // POST: Zonas1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,ResidencialId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", zonas.ResidencialId);
            return View(zonas);
        }

        // GET: Zonas1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas.FindAsync(id);
            if (zonas == null)
            {
                return NotFound();
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", zonas.ResidencialId);
            return View(zonas);
        }

        // POST: Zonas1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,ResidencialId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Zonas zonas)
        {
            if (id != zonas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonasExists(zonas.Id))
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
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", zonas.ResidencialId);
            return View(zonas);
        }

        // GET: Zonas1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .Include(z => z.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return View(zonas);
        }

        // POST: Zonas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonas = await _context.Zonas.FindAsync(id);
            if (zonas != null)
            {
                _context.Zonas.Remove(zonas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonasExists(int id)
        {
            return _context.Zonas.Any(e => e.Id == id);
        }
    }
}
