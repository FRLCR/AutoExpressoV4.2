using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AEFINAL.Context;
using AEFINAL.Models;

namespace AEFINAL.Controllers
{
    public class RegistroController : Controller
    {
        private readonly dbConnect _context;

        public RegistroController(dbConnect context)
        {
            _context = context;
        }

        // GET: Registro
        public async Task<IActionResult> Index()
        {
            var dbConnect = _context.Registros.Include(r => r.Servicio).Include(r => r.VehiculomatriculaNavigation);
            return View(await dbConnect.ToListAsync());
        }

        // GET: Registro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registros == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Servicio)
                .Include(r => r.VehiculomatriculaNavigation)
                .FirstOrDefaultAsync(m => m.NroOrden == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registro/Create
        public IActionResult Create()
        {
            ViewData["Servicioid"] = new SelectList(_context.Servicios, "Id", "Nombre");
            ViewData["Vehiculomatricula"] = new SelectList(_context.Vehiculos, "Matricula", "Matricula");
            return View();
        }

        // POST: Registro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NroOrden,Fecha,Vehiculomatricula,Servicioid")] Registro registro)
        {
            if (!ModelState.IsValid)
            {
                // HACER ESTO MISMO EN EL EDIT
                // llamar a una funcion que devuelva un boolean que chequee duplicados.
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Servicioid"] = new SelectList(_context.Servicios, "Id", "Nombre", registro.Servicioid);
            ViewData["Vehiculomatricula"] = new SelectList(_context.Vehiculos, "Matricula", "Matricula", registro.Vehiculomatricula);
            return View(registro);
        }

        // GET: Registro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registros == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["Servicioid"] = new SelectList(_context.Servicios, "Id", "Nombre", registro.Servicioid);
            ViewData["Vehiculomatricula"] = new SelectList(_context.Vehiculos, "Matricula", "Matricula", registro.Vehiculomatricula);
            return View(registro);
        }

        // POST: Registro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NroOrden,Fecha,Vehiculomatricula,Servicioid")] Registro registro)
        {
            if (id != registro.NroOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.NroOrden))
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
            ViewData["Servicioid"] = new SelectList(_context.Servicios, "Id", "Nombre", registro.Servicioid);
            ViewData["Vehiculomatricula"] = new SelectList(_context.Vehiculos, "Matricula", "Matricula", registro.Vehiculomatricula);
            return View(registro);
        }

        // GET: Registro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registros == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Servicio)
                .Include(r => r.VehiculomatriculaNavigation)
                .FirstOrDefaultAsync(m => m.NroOrden == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registros == null)
            {
                return Problem("Entity set 'dbConnect.Registros'  is null.");
            }
            var registro = await _context.Registros.FindAsync(id);
            if (registro != null)
            {
                _context.Registros.Remove(registro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
          return (_context.Registros?.Any(e => e.NroOrden == id)).GetValueOrDefault();
        }
    }
}
