using ControlAccess.Data;
using ControlAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlAccess.Controllers
{
    public class ResidencialsController : Controller
    {
        private readonly ControlAccessContext _context;

        public ResidencialsController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Residencials
        public async Task<IActionResult> Index()
        {
            var residenciales = await _context.Residencial.ToListAsync();
            return Ok(residenciales);  // Asegúrate de que esto esté devolviendo una lista de objetos correctamente serializados
        }

        // GET: Residencials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residencial = await _context.Residencial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residencial == null)
            {
                return NotFound();
            }

            return Json(residencial);
        }

        // GET: Residencials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Residencials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Residencial residencial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(residencial);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Residencial created successfully" });
            }
            return BadRequest(ModelState);
        }

        // GET: Residencials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residencial = await _context.Residencial.FindAsync(id);
            if (residencial == null)
            {
                return NotFound();
            }
            return View(residencial);
        }

        // PUT: Residencials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Residencial residencial)
        {
            if (id != residencial.Id)
            {
                return BadRequest("El id brindado no coincide con el id de la residencial.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residencial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidencialExists(residencial.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Residencial updated successfully" });
            }
            return BadRequest(residencial);
        }

        // GET: Residencials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residencial = await _context.Residencial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (residencial == null)
            {
                return NotFound();
            }

            return View(residencial);
        }

        // DELETE: Residencials/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var residencial = await _context.Residencial.FindAsync(id);
            if (residencial != null)
            {
                _context.Residencial.Remove(residencial);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Residencial eliminada exitosamente." });
        }

        private bool ResidencialExists(int id)
        {
            return _context.Residencial.Any(e => e.Id == id);
        }
    }
}
