﻿using System;
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
    public class AvenidasController : Controller
    {
        private readonly ControlAccessContext _context;

        public AvenidasController(ControlAccessContext context)
        {
            _context = context;
        }

        // GET: Avenidas
        public async Task<IActionResult> Index()
        {
            var avenidas = await _context.Avenidas
            .Include(a => a.Residencial) 
            .ToListAsync();
            return Ok(avenidas);
        }

        // GET: Avenidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenidas = await _context.Avenidas
                .Include(a => a.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avenidas == null)
            {
                return NotFound();
            }

            return Json(avenidas);
        }

        // GET: Avenidas/Create
        public IActionResult Create()
        {
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address");
            return View();
        }

        // POST: Avenidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Avenidas avenidas)
        {

            if (ModelState.IsValid)
            {
                _context.Add(avenidas);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Avenidas Created successfuly" });
            }
            
            return BadRequest(ModelState);
        } 

            // GET: Avenidas/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenidas = await _context.Avenidas.FindAsync(id);
            if (avenidas == null)
            {
                return NotFound();
            }
            ViewData["ResidencialId"] = new SelectList(_context.Residencial, "Id", "address", avenidas.ResidencialId);
            return View(avenidas);
        }

        // PUT: Avenidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]        
        public async Task<IActionResult> Edit(int id, [FromBody] Avenidas avenidas)
        {
            if (id != avenidas.Id)
            {
                return BadRequest("El id brindado no coincide con el id de la Avenida.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    avenidas.UpdatedDate = DateTime.Now;
                    _context.Update(avenidas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvenidasExists(avenidas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new { message = "Recidencial updated successfully" });
            }
            
            return BadRequest(avenidas);
        }

        // GET: Avenidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenidas = await _context.Avenidas
                .Include(a => a.Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avenidas == null)
            {
                return NotFound();
            }

            return View(avenidas);
        }

        // DELETE: Avenidas/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avenidas = await _context.Avenidas.FindAsync(id);
            if (avenidas != null)
            {
                _context.Avenidas.Remove(avenidas);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Avenida eliminada exitosamente"});
        }

        private bool AvenidasExists(int id)
        {
            return _context.Avenidas.Any(e => e.Id == id);
        }
    }
}
