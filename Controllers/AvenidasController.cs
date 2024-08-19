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
    public class AvenidasController : Controller
    {
        private readonly ControlAccessContext _context;

        public AvenidasController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Avenidas
        public async Task<IActionResult> Index()
        {
            var controlAccessContext = _context.Avenidas.Include(a => a.Residencial);
            return View(await controlAccessContext.ToListAsync());
        }

        // GET: Avenidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenidas = await _context.Avenidas
                .Include(a => a.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avenidas == null)
            {
                return NotFound();
            }

            return View(avenidas);
        }

        // GET: Avenidas/Create
        public IActionResult Create()
        {
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            return View();
        }

        // POST: Avenidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,ResidencialId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Avenidas avenidas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avenidas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", avenidas.ResidencialId);
            return View(avenidas);
        }

        // GET: Avenidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenidas = await _context.Avenidas.FindAsync(id);
            if (avenidas == null)
            {
                return NotFound();
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", avenidas.ResidencialId);
            return View(avenidas);
        }

        // POST: Avenidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,ResidencialId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Avenidas avenidas)
        {
            if (id != avenidas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avenidas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvenidasExists(avenidas.Id))
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
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", avenidas.ResidencialId);
            return View(avenidas);
        }

        // GET: Avenidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenidas = await _context.Avenidas
                .Include(a => a.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avenidas == null)
            {
                return NotFound();
            }

            return View(avenidas);
        }

        // POST: Avenidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avenidas = await _context.Avenidas.FindAsync(id);
            if (avenidas != null)
            {
                _context.Avenidas.Remove(avenidas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvenidasExists(int id)
        {
            return _context.Avenidas.Any(e => e.Id == id);
        }
    }
}
