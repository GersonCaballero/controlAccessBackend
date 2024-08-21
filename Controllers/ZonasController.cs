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
    public class ZonasController : Controller
    {
        private readonly ControlAccessContext _context;

        public ZonasController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Zonas
        public async Task<IActionResult> Index()
        {
            var zonas = await _context.Zonas.Include(a => a.Residencial).ToListAsync();
            return Ok(zonas);
        }

        // GET: Zonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .Include(z => z.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return Json(zonas);
        }

        // GET: Zonas/Create
        public IActionResult Create()
        {
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonas);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Zona created successfully"});
            }            
            return BadRequest(ModelState);
        }

        // GET: Zonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas.FindAsync(id);
            if (zonas == null)
            {
                return NotFound();
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", zonas.ResidencialId);
            return View(zonas);
        }

        // PUT: Zonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Zonas zonas)
        {
            if (id != zonas.Id)
            {
                return BadRequest("El id brindado no coincide con el id de la zona.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    zonas.UpdatedDate = DateTime.Now;
                    _context.Update(zonas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonasExists(zonas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new {message = "Zona updated successfuly"});
            }
            //ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", zonas.ResidencialId);
            return BadRequest(zonas);
        }

        // GET: Zonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .Include(z => z.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return View(zonas);
        }

        // DELETE: Zonas/Delete/5
        [HttpDelete, ActionName("Delete")]  
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonas = await _context.Zonas.FindAsync(id);
            if (zonas != null)
            {
                _context.Zonas.Remove(zonas);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Zona eliminada exitosamente. "});
        }

        private bool ZonasExists(int id)
        {
            return _context.Zonas.Any(e => e.Id == id);
        }
    }
}
