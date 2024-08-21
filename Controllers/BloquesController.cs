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
            var bloque = await _context.Bloque.Include(a=>a.Residencial).ToListAsync();
            return Ok(bloque);
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

            return Json(bloque);
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
        public async Task<IActionResult> Create([FromBody] Bloque bloque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloque);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Bloque created successfuly" });
            }            
            return BadRequest(ModelState);
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

        // PUT: Bloques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]    
        public async Task<IActionResult> Edit(int id, [FromBody] Bloque bloque)
        {
            if (id != bloque.Id)
            {
                return BadRequest("El id brindando no coincide con el id del bloque");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bloque.UpdatedDate = DateTime.Now;
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
                return Ok(new { message = "Bloque  updated successsfuly" });
            }
            
            return BadRequest(bloque);
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

        // DELETE: Bloques/Delete/5
        [HttpDelete, ActionName("Delete")]       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloque = await _context.Bloque.FindAsync(id);
            if (bloque != null)
            {
                _context.Bloque.Remove(bloque);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Residencial eliminada exitosamente."});
        }

        private bool BloqueExists(int id)
        {
            return _context.Bloque.Any(e => e.Id == id);
        }
    }
}
