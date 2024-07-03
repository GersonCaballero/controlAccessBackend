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
    public class InmueblesController : Controller
    {
        private readonly ControlAccessContext _context;

        public InmueblesController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Inmuebles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inmuebles.ToListAsync());
        }

        // GET: Inmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmuebles = await _context.Inmuebles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inmuebles == null)
            {
                return NotFound();
            }

            return View(inmuebles);
        }

        // GET: Inmuebles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inmuebles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Inmuebles inmuebles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inmuebles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inmuebles);
        }

        // GET: Inmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmuebles = await _context.Inmuebles.FindAsync(id);
            if (inmuebles == null)
            {
                return NotFound();
            }
            return View(inmuebles);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Inmuebles inmuebles)
        {
            if (id != inmuebles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inmuebles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InmueblesExists(inmuebles.Id))
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
            return View(inmuebles);
        }

        // GET: Inmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmuebles = await _context.Inmuebles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inmuebles == null)
            {
                return NotFound();
            }

            return View(inmuebles);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inmuebles = await _context.Inmuebles.FindAsync(id);
            if (inmuebles != null)
            {
                _context.Inmuebles.Remove(inmuebles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InmueblesExists(int id)
        {
            return _context.Inmuebles.Any(e => e.Id == id);
        }
    }
}
