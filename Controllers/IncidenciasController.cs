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
    public class IncidenciasController : Controller
    {
        private readonly ControlAccessContext _context;

        public IncidenciasController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Incidencias
        public async Task<IActionResult> Index()
        {
            var incidencias = await _context.Incidencias.Include(i => i.Casa).Include(i => i.Usuario).ToListAsync();            
            return Ok(incidencias);
        }

        // GET: Incidencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencias = await _context.Incidencias
                .Include(i => i.Casa)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidencias == null)
            {
                return NotFound();
            }

            return Json(incidencias);
        }

        // GET: Incidencias/Create
        public IActionResult Create()
        {
            ViewData["CasaId"] = new SelectList(_context.Casas, "Id", "name");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido");
            return View();
        }

        // POST: Incidencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]       
        public async Task<IActionResult> Create([FromBody] Incidencias incidencias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidencias);
                await _context.SaveChangesAsync();
                return Ok("Incidencia creada exitosamente.");
            }
            
            return BadRequest(ModelState);
        }

        // GET: Incidencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencias = await _context.Incidencias.FindAsync(id);
            if (incidencias == null)
            {
                return NotFound();
            }
            ViewData["CasaId"] = new SelectList(_context.Casas, "Id", "name", incidencias.CasaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido", incidencias.UsuarioId);
            return View(incidencias);
        }

        // PUT: Incidencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]      
        public async Task<IActionResult> Edit(int id, [FromBody] Incidencias incidencias)
        {
            if (id != incidencias.Id)
            {
                return BadRequest("El id brindado no coincide con el id de Insidencias.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidenciasExists(incidencias.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Incidencia actualizada exitosamente." });
            }
          return BadRequest(incidencias);
        }

        // GET: Incidencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencias = await _context.Incidencias
                .Include(i => i.Casa)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidencias == null)
            {
                return NotFound();
            }

            return View(incidencias);
        }

        // DELETE: Incidencias/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidencias = await _context.Incidencias.FindAsync(id);
            if (incidencias != null)
            {
                _context.Incidencias.Remove(incidencias);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Insidencia eliminado exitosamente." });
        }

        private bool IncidenciasExists(int id)
        {
            return _context.Incidencias.Any(e => e.Id == id);
        }
    }
}
