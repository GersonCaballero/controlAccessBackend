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
    public class VisitantesController : Controller
    {
        private readonly ControlAccessContext _context;

        public VisitantesController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Visitantes
        public async Task<IActionResult> Index()
        {
            var visitantes = await _context.Visitantes.ToListAsync();
            return Ok(visitantes);
        }

        // GET: Visitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitantes = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitantes == null)
            {
                return NotFound();
            }

            return Json(visitantes);
        }

        // GET: Visitantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Visitantes visitantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitantes);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Visitante creado exitosamente." });
            }
            return BadRequest(ModelState);
        }

        // GET: Visitantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitantes = await _context.Visitantes.FindAsync(id);
            if (visitantes == null)
            {
                return NotFound();
            }
            return View(visitantes);
        }

        // PUT: Visitantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Visitantes visitantes)
        {
            if (id != visitantes.Id)
            {
                return BadRequest("El id brindado no coincide con el id del visitante.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitantesExists(visitantes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Visitante actualizada exitosamente." });
            }
            return BadRequest(visitantes);
        }

        // GET: Visitantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitantes = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitantes == null)
            {
                return NotFound();
            }

            return View(visitantes);
        }

        // DELETE: Visitantes/Delete/5
        [HttpDelete, ActionName("Delete")]       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitantes = await _context.Visitantes.FindAsync(id);
            if (visitantes != null)
            {
                _context.Visitantes.Remove(visitantes);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Visitante eliminado exitosamente." });
        }

        private bool VisitantesExists(int id)
        {
            return _context.Visitantes.Any(e => e.Id == id);
        }
    }
}
