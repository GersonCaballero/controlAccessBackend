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
    public class AccesosController : Controller
    {
        private readonly ControlAccessContext _context;

        public AccesosController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Accesos
        public async Task<IActionResult> Index()
        {
            var accesos = await _context.Accesos
                .Include(a => a.Casa)
                .Include(a => a.Usuario)
                .Include(a => a.Vehiculo)
                .Include(a => a.Visitante)
                .ToListAsync();
            return Ok(accesos);
        }

        // GET: Accesos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesos = await _context.Accesos
                .Include(a => a.Casa)
                .Include(a => a.Usuario)
                .Include(a => a.Vehiculo)
                .Include(a => a.Visitante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accesos == null)
            {
                return NotFound();
            }

            return Json(accesos);
        }

        // GET: Accesos/Create
        public IActionResult Create()
        {
            ViewData["CasaId"] = new SelectList(_context.Casas, "Id", "name");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Marca");
            ViewData["VisitanteId"] = new SelectList(_context.Visitantes, "Id", "Apellido");
            return View();
        }

        // POST: Accesos/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Accesos accesos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesos);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Acceso creado exitosamente" });
            }

            return BadRequest(ModelState);
        }

        // GET: Accesos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesos = await _context.Accesos.FindAsync(id);
            if (accesos == null)
            {
                return NotFound();
            }
            ViewData["CasaId"] = new SelectList(_context.Casas, "Id", "name", accesos.CasaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido", accesos.UsuarioId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Marca", accesos.VehiculoId);
            ViewData["VisitanteId"] = new SelectList(_context.Visitantes, "Id", "Apellido", accesos.VisitanteId);
            return View(accesos);
        }

        // PUT: Accesos/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Accesos accesos)
        {
            if (id != accesos.Id)
            {
                return BadRequest("El id brindado no coincide con el id de Accesos.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accesos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesosExists(accesos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Acceso actualizado exitosamente" });
            }
            return BadRequest(accesos);
        }

        // GET: Accesos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesos = await _context.Accesos
                .Include(a => a.Casa)
                .Include(a => a.Usuario)
                .Include(a => a.Vehiculo)
                .Include(a => a.Visitante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accesos == null)
            {
                return NotFound();
            }

            return View(accesos);
        }

        // DELETE: Accesos/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accesos = await _context.Accesos.FindAsync(id);
            if (accesos != null)
            {
                _context.Accesos.Remove(accesos);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Acceso eliminado exitosamente." });
        }

        private bool AccesosExists(int id)
        {
            return _context.Accesos.Any(e => e.Id == id);
        }
    }
}
