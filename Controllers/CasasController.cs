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
    public class CasasController : Controller
    {
        private readonly ControlAccessContext _context;

        public CasasController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Casas
        public async Task<IActionResult> Index()
        {
            var casas = await _context.Casas.Include(c => c.Avenidas)
                .Include(c => c.Bloque)
                .Include(c => c.Calle)
                .Include(c => c.Zona).ToListAsync();           
            return Ok(casas);
        }

        // GET: Casas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casas = await _context.Casas
                .Include(c => c.Avenidas)
                .Include(c => c.Bloque)
                .Include(c => c.Calle)             
                .Include(c => c.Zona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casas == null)
            {
                return NotFound();
            }

            return Json(casas);
        }

        // GET: Casas/Create
        public IActionResult Create()
        {
            ViewData["IdAvenida"] = new SelectList(_context.Avenidas, "Id", "name");
            ViewData["IdBloque"] = new SelectList(_context.Bloque, "Id", "name");
            ViewData["IdCalle"] = new SelectList(_context.Calles, "Id", "name");
            //ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            ViewData["IdZona"] = new SelectList(_context.Zonas, "Id", "name");
            return View();
        }

        // POST: Casas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Casas casas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casas);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Entidad casa creada exitosamente" });
            }
            return BadRequest(ModelState);
        }

        // GET: Casas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casas = await _context.Casas.FindAsync(id);
            if (casas == null)
            {
                return NotFound();
            }
            ViewData["IdAvenida"] = new SelectList(_context.Avenidas, "Id", "name", casas.IdAvenida);
            ViewData["IdBloque"] = new SelectList(_context.Bloque, "Id", "name", casas.IdBloque);
            ViewData["IdCalle"] = new SelectList(_context.Calles, "Id", "name", casas.IdCalle);
            //ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            ViewData["IdZona"] = new SelectList(_context.Zonas, "Id", "name", casas.IdZona);
            return View(casas);
        }

        // PUT: Casas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Casas casas)
        {
            if (id != casas.Id)
            {
                return BadRequest("El id brindado no coincide con el id de la residencial.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    casas.UpdatedDate = DateTime.Now;
                    _context.Update(casas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasasExists(casas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Entidad casa Actualizada corectamente" } );
            }
            return BadRequest(casas);
        }

        // GET: Casas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casas = await _context.Casas
                .Include(c => c.Avenidas)
                .Include(c => c.Bloque)
                .Include(c => c.Calle)                
                .Include(c => c.Zona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casas == null)
            {
                return NotFound();
            }

            return View(casas);
        }

        // DELETE: Casas/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casas = await _context.Casas.FindAsync(id);
            if (casas != null)
            {
                _context.Casas.Remove(casas);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Casa eliminada exitosamente." });
        }

        private bool CasasExists(int id)
        {
            return _context.Casas.Any(e => e.Id == id);
        }
    }
}
