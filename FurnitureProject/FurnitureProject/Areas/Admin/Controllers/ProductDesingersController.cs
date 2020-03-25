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
    public class ProductDesingersController : Controller
    {
        private readonly FurnitureDbContext _context;

        public ProductDesingersController(FurnitureDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductDesingers
        public async Task<IActionResult> Index()
        {
            return View(await _context.productDesingers.ToListAsync());
        }

        // GET: Admin/ProductDesingers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDesinger = await _context.productDesingers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDesinger == null)
            {
                return NotFound();
            }

            return View(productDesinger);
        }

        // GET: Admin/ProductDesingers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductDesingers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductDesinger productDesinger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDesinger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productDesinger);
        }

        // GET: Admin/ProductDesingers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDesinger = await _context.productDesingers.FindAsync(id);
            if (productDesinger == null)
            {
                return NotFound();
            }
            return View(productDesinger);
        }

        // POST: Admin/ProductDesingers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductDesinger productDesinger)
        {
            if (id != productDesinger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDesinger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDesingerExists(productDesinger.Id))
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
            return View(productDesinger);
        }

        // GET: Admin/ProductDesingers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDesinger = await _context.productDesingers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDesinger == null)
            {
                return NotFound();
            }

            return View(productDesinger);
        }

        // POST: Admin/ProductDesingers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDesinger = await _context.productDesingers.FindAsync(id);
            _context.productDesingers.Remove(productDesinger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDesingerExists(int id)
        {
            return _context.productDesingers.Any(e => e.Id == id);
        }
    }
}
