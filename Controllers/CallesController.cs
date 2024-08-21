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
    public class CallesController : Controller
    {
        private readonly ControlAccessContext _context;

        public CallesController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Calles
        public async Task<IActionResult> Index()
        {            
            var calles = await _context.Calles.Include(c => c.Residencial).ToListAsync();
            return Ok(calles);
        }

        // GET: Calles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calles = await _context.Calles
                .Include(c => c.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calles == null)
            {
                return NotFound();
            }

            return Json(calles);
        }

        // GET: Calles/Create
        public IActionResult Create()
        {
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            return View();
        }

        // POST: Calles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]      
        public async Task<IActionResult> Create([FromBody] Calles calles)
                {
            if (ModelState.IsValid)
            {                
                _context.Add(calles);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Calles created successfully" });
            }           
            return BadRequest(ModelState);
        }

        // GET: Calles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calles = await _context.Calles.FindAsync(id);
            if (calles == null)
            {
                return NotFound();
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", calles.ResidencialId);
            return View(calles);
        }

        // PUT: Calles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]        
        public async Task<IActionResult> Edit(int id, [FromBody] Calles calles)
        {
            if (id != calles.Id)
            {
                return BadRequest("El id brindado no coincide con el id de la calle.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    calles.UpdatedDate = DateTime.Now;
                    _context.Update(calles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallesExists(calles.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Calle Updated successfully" });
            }            
            return BadRequest(calles);
        }

        // GET: Calles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calles = await _context.Calles
                .Include(c => c.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calles == null)
            {
                return NotFound();
            }

            return View(calles);
        }

        // DELETE: Calles/Delete/5
        [HttpDelete, ActionName("Delete")]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calles = await _context.Calles.FindAsync(id);
            if (calles != null)
            {
                _context.Calles.Remove(calles);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Calle Eliminda exitosamente."});
        }

        private bool CallesExists(int id)
        {
            return _context.Calles.Any(e => e.Id == id);
        }
    }
}
