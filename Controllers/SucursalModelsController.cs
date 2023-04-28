using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViajesColaboradores.Data;
using ViajesColaboradores.Models;

namespace ViajesColaboradores.Controllers
{
    public class SucursalModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SucursalModels
        public async Task<IActionResult> Index()
        {
              return _context.SucursalModel != null ? 
                          View(await _context.SucursalModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SucursalModel'  is null.");
        }

        // GET: SucursalModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SucursalModel == null)
            {
                return NotFound();
            }

            var sucursalModel = await _context.SucursalModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursalModel == null)
            {
                return NotFound();
            }

            return View(sucursalModel);
        }

        // GET: SucursalModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SucursalModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreSucursal,Colaborador,Distancia")] SucursalModel sucursalModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursalModel);
        }

        // GET: SucursalModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SucursalModel == null)
            {
                return NotFound();
            }

            var sucursalModel = await _context.SucursalModel.FindAsync(id);
            if (sucursalModel == null)
            {
                return NotFound();
            }
            return View(sucursalModel);
        }

        // POST: SucursalModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreSucursal,Colaborador,Distancia")] SucursalModel sucursalModel)
        {
            if (id != sucursalModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalModelExists(sucursalModel.Id))
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
            return View(sucursalModel);
        }

        // GET: SucursalModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SucursalModel == null)
            {
                return NotFound();
            }

            var sucursalModel = await _context.SucursalModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursalModel == null)
            {
                return NotFound();
            }

            return View(sucursalModel);
        }

        // POST: SucursalModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SucursalModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SucursalModel'  is null.");
            }
            var sucursalModel = await _context.SucursalModel.FindAsync(id);
            if (sucursalModel != null)
            {
                _context.SucursalModel.Remove(sucursalModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalModelExists(int id)
        {
          return (_context.SucursalModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
