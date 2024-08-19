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
            var tarifas = await _context.Tarifas.Include(t => t.Inmuebles).ToListAsync();
            return Ok(tarifas);
        }

        // GET: Tarifas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "El id proporcionado no coincide con el id de tarifas"});
            }

            var tarifas = await _context.Tarifas
                .Include(t => t.Inmuebles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarifas == null)
            {
                return NotFound();
            }

            return Json(tarifas);
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
        public async Task<IActionResult> Create([FromBody] Tarifas tarifas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifas);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Tarifas created successfully"});
            }
            
            return BadRequest(ModelState);
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

        // PUT: Tarifas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]       
        public async Task<IActionResult> Edit(int id, [FromBody] Tarifas tarifas)
        {
            if (id != tarifas.Id)
            {
                return BadRequest("El id brindado no coincide con el id de Tarifas");
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
                return Ok(new { message = "Tarifas Updated Successfully"});
            }            
            return BadRequest(tarifas);
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

        // DELETE: Tarifas/Delete/5
        [HttpDelete, ActionName("Delete")]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarifas = await _context.Tarifas.FindAsync(id);
            if (tarifas != null)
            {
                _context.Tarifas.Remove(tarifas);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Tarifas Eleminada exitosamente" });
        }

        private bool TarifasExists(int id)
        {
            return _context.Tarifas.Any(e => e.Id == id);
        }
    }
}
