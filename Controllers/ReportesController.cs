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
    public class ReportesController : Controller
    {
        private readonly ControlAccessContext _context;

        public ReportesController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Reportes
        public async Task<IActionResult> Index()
        {
            var reportes = await _context.Reportes.Include(r => r.Usuario).ToListAsync();            
            return Ok(reportes);
        }

        // GET: Reportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes = await _context.Reportes
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportes == null)
            {
                return NotFound();
            }

            return Json(reportes);
        }

        // GET: Reportes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido");
            return View();
        }

        // POST: Reportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Reportes reportes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportes);
                await _context.SaveChangesAsync();
                return Ok(new {message = "Reporte creado exitosamente."});
            }

            return BadRequest(ModelState);
        }

        // GET: Reportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes = await _context.Reportes.FindAsync(id);
            if (reportes == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido", reportes.UsuarioId);
            return View(reportes);
        }

        // PUT: Reportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Reportes reportes)
        {
            if (id != reportes.Id)
            {
                return BadRequest("El id brindado no coincide con el id de Reportes.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportesExists(reportes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Reporte actualizada exitosamente." });
            }            
            return BadRequest(reportes);
        }

        // GET: Reportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes = await _context.Reportes
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportes == null)
            {
                return NotFound();
            }

            return View(reportes);
        }

        // DELETE: Reportes/Delete/5
        [HttpDelete, ActionName("Delete")]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportes = await _context.Reportes.FindAsync(id);
            if (reportes != null)
            {
                _context.Reportes.Remove(reportes);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Reporte eliminado exitosamente." });
        }

        private bool ReportesExists(int id)
        {
            return _context.Reportes.Any(e => e.Id == id);
        }
    }
}
