using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FurnitureProject.Data;
using FurnitureProject.Data.Entities;

namespace FurnitureProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarkasController : Controller
    {
        private readonly FurnitureDbContext _context;

        public MarkasController(FurnitureDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Markas
        public async Task<IActionResult> Index()
        {
            var furnitureDbContext = _context.Markas.Include(m => m.Categoriy);
            return View(await furnitureDbContext.ToListAsync());
        }

        // GET: Admin/Markas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marka = await _context.Markas
                .Include(m => m.Categoriy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // GET: Admin/Markas/Create
        public IActionResult Create()
        {
            ViewData["CategoriyId"] = new SelectList(_context.Categoriys, "Id", "Name");
            return View();
        }

        // POST: Admin/Markas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoriyId,Name")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriyId"] = new SelectList(_context.Categoriys, "Id", "Name", marka.CategoriyId);
            return View(marka);
        }

        // GET: Admin/Markas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marka = await _context.Markas.FindAsync(id);
            if (marka == null)
            {
                return NotFound();
            }
            ViewData["CategoriyId"] = new SelectList(_context.Categoriys, "Id", "Name", marka.CategoriyId);
            return View(marka);
        }

        // POST: Admin/Markas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoriyId,Name")] Marka marka)
        {
            if (id != marka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkaExists(marka.Id))
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
            ViewData["CategoriyId"] = new SelectList(_context.Categoriys, "Id", "Name", marka.CategoriyId);
            return View(marka);
        }

        // GET: Admin/Markas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marka = await _context.Markas
                .Include(m => m.Categoriy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // POST: Admin/Markas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marka = await _context.Markas.FindAsync(id);
            _context.Markas.Remove(marka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkaExists(int id)
        {
            return _context.Markas.Any(e => e.Id == id);
        }
    }
}
