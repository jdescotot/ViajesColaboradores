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
    public class TransportistaModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportistaModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransportistaModels
        public async Task<IActionResult> Index()
        {
              return _context.TransportistaModel != null ? 
                          View(await _context.TransportistaModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TransportistaModel'  is null.");
        }

        // GET: TransportistaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportistaModel == null)
            {
                return NotFound();
            }

            var transportistaModel = await _context.TransportistaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportistaModel == null)
            {
                return NotFound();
            }

            return View(transportistaModel);
        }

        // GET: TransportistaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransportistaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tarifa,Nombre,LimiteViajes")] TransportistaModel transportistaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportistaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportistaModel);
        }

        // GET: TransportistaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportistaModel == null)
            {
                return NotFound();
            }

            var transportistaModel = await _context.TransportistaModel.FindAsync(id);
            if (transportistaModel == null)
            {
                return NotFound();
            }
            return View(transportistaModel);
        }

        // POST: TransportistaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tarifa,Nombre,LimiteViajes")] TransportistaModel transportistaModel)
        {
            if (id != transportistaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportistaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportistaModelExists(transportistaModel.Id))
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
            return View(transportistaModel);
        }

        // GET: TransportistaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportistaModel == null)
            {
                return NotFound();
            }

            var transportistaModel = await _context.TransportistaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportistaModel == null)
            {
                return NotFound();
            }

            return View(transportistaModel);
        }

        // POST: TransportistaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportistaModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransportistaModel'  is null.");
            }
            var transportistaModel = await _context.TransportistaModel.FindAsync(id);
            if (transportistaModel != null)
            {
                _context.TransportistaModel.Remove(transportistaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportistaModelExists(int id)
        {
          return (_context.TransportistaModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
