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
    public class VehiculosController : Controller
    {
        private readonly ControlAccessContext _context;

        public VehiculosController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            var vehiculos = await _context.Vehiculos.Include(v => v.Usuario).ToListAsync();
            
            return Ok(vehiculos);
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return Json(vehiculos);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] Vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculos);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Vehiculo creado exitosamente" });
            }            
            return BadRequest(ModelState);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido", vehiculos.UsuarioId);
            return View(vehiculos);
        }

        // PUT: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]        
        public async Task<IActionResult> Edit(int id, [FromBody] Vehiculos vehiculos)
        {
            if (id != vehiculos.Id)
            {
                return BadRequest("El id brindado no coincide con el id de Vehiculos.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vehiculos.UpdatedDate = DateTime.Now;
                    _context.Update(vehiculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosExists(vehiculos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Vehiculo actualizado exitosamente" });
            }            
            return BadRequest(vehiculos);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return View(vehiculos);
        }

        // DELETE: Vehiculos/Delete/5
        [HttpDelete, ActionName("Delete")]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculos = await _context.Vehiculos.FindAsync(id);
            if (vehiculos != null)
            {
                _context.Vehiculos.Remove(vehiculos);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Vehiculo eliminado exitosamente." });
        }

        private bool VehiculosExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
