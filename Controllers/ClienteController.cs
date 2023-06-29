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
    public class ClienteController : Controller
    {
        private readonly dbConnect _context;

        public ClienteController(dbConnect context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
              return _context.Clientes != null ? 
                          View(await _context.Clientes.ToListAsync()) :
                          Problem("Entity set 'dbConnect.Clientes'  is null.");
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Documento,NombreCompleto, CorreoElectronico")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                bool cliDNIExist = _context.Clientes.FirstOrDefault(c =>
            c.Documento == cliente.Documento) != null;

                bool clieMail = _context.Clientes.FirstOrDefault(c =>
            c.CorreoElectronico == cliente.CorreoElectronico) != null;

                if (cliDNIExist)
                {
                    ModelState.AddModelError("Documento", "Ya existe un Cliente con ese Documento.");
                    return View(cliente);
                }else if (clieMail)

                {
                    ModelState.AddModelError("CorreoElectronico", "Ya existe un Cliente con ese CorreoElectronico.");
                    return View(cliente);
                }

                else
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Documento,NombreCompleto,CorreoElectronico")] Cliente cliente)
        {
            if (id != cliente.Documento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bool cliMailExist = _context.Clientes.FirstOrDefault(c =>
                     c.CorreoElectronico == cliente.CorreoElectronico) != null;

                    if (cliMailExist)
                    {
                        ModelState.AddModelError("CorreoElectronico", "Ya existe un cliente con ese CorreoElectronico.");

                        return View(cliente);
                    }
                    
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Documento))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'dbConnect.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
