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
    public class TipoUsuariosController : Controller
    {
        private readonly ControlAccessContext _context;

        public TipoUsuariosController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: TipoUsuarios
        public async Task<IActionResult> Index()
        {
            var tipoUsuario = await _context.TipoUsuario.ToListAsync();
            return Ok(tipoUsuario);
        }

        // GET: TipoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return Json(tipoUsuario);
        }

        // GET: TipoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUsuario);
                await _context.SaveChangesAsync();
                return Ok(new {message = "TipoUsuarios created successfully"});
            }
            return BadRequest(ModelState);
        }

        // GET: TipoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return View(tipoUsuario);
        }

        // PUT: TipoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]        
        public async Task<IActionResult> Edit(int id, [FromBody] TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.Id)
            {
                return BadRequest("El id brindado no coincide con el id de TipoUsuarios.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUsuarioExists(tipoUsuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new {message = "TipoUsuarios updated successfully"});
            }
            return BadRequest(tipoUsuario);
        }

        // GET: TipoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return View(tipoUsuario);
        }

        // DELETE: TipoUsuarios/Delete/5
        [HttpDelete, ActionName("Delete")]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario != null)
            {
                _context.TipoUsuario.Remove(tipoUsuario);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "TipoUsuarios Eliminado exitosamente."});
        }

        private bool TipoUsuarioExists(int id)
        {
            return _context.TipoUsuario.Any(e => e.Id == id);
        }
    }
}
