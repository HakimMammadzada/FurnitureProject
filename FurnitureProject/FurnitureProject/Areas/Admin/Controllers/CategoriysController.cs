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
    public class CategoriysController : Controller
    {
        private readonly FurnitureDbContext _context;

        public CategoriysController(FurnitureDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Categoriys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoriys.ToListAsync());
        }

        // GET: Admin/Categoriys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriy = await _context.Categoriys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriy == null)
            {
                return NotFound();
            }

            return View(categoriy);
        }

        // GET: Admin/Categoriys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categoriys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Categoriy categoriy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriy);
        }

        // GET: Admin/Categoriys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriy = await _context.Categoriys.FindAsync(id);
            if (categoriy == null)
            {
                return NotFound();
            }
            return View(categoriy);
        }

        // POST: Admin/Categoriys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Categoriy categoriy)
        {
            if (id != categoriy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriyExists(categoriy.Id))
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
            return View(categoriy);
        }

        // GET: Admin/Categoriys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriy = await _context.Categoriys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriy == null)
            {
                return NotFound();
            }

            return View(categoriy);
        }

        // POST: Admin/Categoriys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriy = await _context.Categoriys.FindAsync(id);
            _context.Categoriys.Remove(categoriy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriyExists(int id)
        {
            return _context.Categoriys.Any(e => e.Id == id);
        }
    }
}
