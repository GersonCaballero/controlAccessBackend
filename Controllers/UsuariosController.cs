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
            var controlAccessContext = _context.Usuarios
                .Include(u => u.Casas)
                .Include(u => u.Inmuebles)
                .Include(u => u.TipoUsuario);
            return View(await controlAccessContext.ToListAsync());
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

            return View(usuarios);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,CorreoElectronico,NumeroCelular,NombreUsuario,Contrasena,IdTipoDeUsuario,IdCasa,IdInmueble,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                // Encriptar la contraseña antes de guardarla
                usuarios.Contrasena = HelperCryptography.EncriptarContrasena(usuarios.Contrasena);

                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCasa"] = new SelectList(_context.Casas, "Id", "name", usuarios.IdCasa);
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy", usuarios.IdInmueble);
            ViewData["IdTipoDeUsuario"] = new SelectList(_context.TipoUsuario, "Id", "CreatedBy", usuarios.IdTipoDeUsuario);
            return View(usuarios);
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

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,CorreoElectronico,NumeroCelular,NombreUsuario,Contrasena,IdTipoDeUsuario,IdCasa,IdInmueble,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Encriptar la contraseña antes de guardarla
                    usuarios.Contrasena = HelperCryptography.EncriptarContrasena(usuarios.Contrasena);

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
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCasa"] = new SelectList(_context.Casas, "Id", "name", usuarios.IdCasa);
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "Id", "CreatedBy", usuarios.IdInmueble);
            ViewData["IdTipoDeUsuario"] = new SelectList(_context.TipoUsuario, "Id", "CreatedBy", usuarios.IdTipoDeUsuario);
            return View(usuarios);
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

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios != null)
            {
                _context.Usuarios.Remove(usuarios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
