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
    public class ColaboratorModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColaboratorModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ColaboratorModels
        public async Task<IActionResult> Index()
        {
              return _context.ColaboratorModel != null ? 
                          View(await _context.ColaboratorModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ColaboratorModel'  is null.");
        }

        // GET: ColaboratorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ColaboratorModel == null)
            {
                return NotFound();
            }

            var colaboratorModel = await _context.ColaboratorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboratorModel == null)
            {
                return NotFound();
            }

            return View(colaboratorModel);
        }

        // GET: ColaboratorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColaboratorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Direccion,LimiteViajes")] ColaboratorModel colaboratorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboratorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboratorModel);
        }

        // GET: ColaboratorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ColaboratorModel == null)
            {
                return NotFound();
            }

            var colaboratorModel = await _context.ColaboratorModel.FindAsync(id);
            if (colaboratorModel == null)
            {
                return NotFound();
            }
            return View(colaboratorModel);
        }

        // POST: ColaboratorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Direccion,LimiteViajes")] ColaboratorModel colaboratorModel)
        {
            if (id != colaboratorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboratorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboratorModelExists(colaboratorModel.Id))
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
            return View(colaboratorModel);
        }

        // GET: ColaboratorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ColaboratorModel == null)
            {
                return NotFound();
            }

            var colaboratorModel = await _context.ColaboratorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboratorModel == null)
            {
                return NotFound();
            }

            return View(colaboratorModel);
        }

        // POST: ColaboratorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ColaboratorModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ColaboratorModel'  is null.");
            }
            var colaboratorModel = await _context.ColaboratorModel.FindAsync(id);
            if (colaboratorModel != null)
            {
                _context.ColaboratorModel.Remove(colaboratorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboratorModelExists(int id)
        {
          return (_context.ColaboratorModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
