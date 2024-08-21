using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlAccess.Data;
using ControlAccess.Models;
using MvcCoreUtilidades.Helpers; // Asegúrate de incluir el espacio de nombres correcto

namespace ControlAccess.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ControlAccessContext _context;

        public UsuariosController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Casas)
                .Include(u => u.Inmuebles)
                .Include(u => u.TipoUsuario).ToListAsync();
            return Ok(usuarios);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .Include(u => u.Casas)
                .Include(u => u.Inmuebles)
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Json(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdCasa"] = new SelectList(_context.Casas, "Id", "name");
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy");
            ViewData["IdTipoDeUsuario"] = new SelectList(_context.TipoUsuario, "Id", "CreatedBy");
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                // Encriptar la contraseña antes de guardarla
                usuarios.Contrasena = HelperCryptography.EncriptarContrasena(usuarios.Contrasena);

                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return Ok(new {message = "Usuarios created successfully"});
            }
            
            return BadRequest(ModelState);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            ViewData["IdCasa"] = new SelectList(_context.Casas, "Id", "name", usuarios.IdCasa);
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy", usuarios.IdInmueble);
            ViewData["IdTipoDeUsuario"] = new SelectList(_context.TipoUsuario, "Id", "CreatedBy", usuarios.IdTipoDeUsuario);
            return View(usuarios);
        }

        // PUT: Usuarios/Edit/5
        [HttpPut]        
        public async Task<IActionResult> Edit(int id, [FromBody] Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return BadRequest("El id brindado no coincide con el id de Usuarios.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Encriptar la contraseña antes de guardarla
                    usuarios.Contrasena = HelperCryptography.EncriptarContrasena(usuarios.Contrasena);
                    usuarios.UpdatedDate = DateTime.Now;
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Usuarios Updated successfully" });
            }           
            return BadRequest(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .Include(u => u.Casas)
                .Include(u => u.Inmuebles)
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // DELETE: Usuarios/Delete/5
        [HttpDelete, ActionName("Delete")]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios != null)
            {
                _context.Usuarios.Remove(usuarios);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Usuarios eliminado exitosamente." });
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
