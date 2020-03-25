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
    public class ProductCountriesController : Controller
    {
        private readonly FurnitureDbContext _context;

        public ProductCountriesController(FurnitureDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductCountries
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCountries.ToListAsync());
        }

        // GET: Admin/ProductCountries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCountry = await _context.ProductCountries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCountry == null)
            {
                return NotFound();
            }

            return View(productCountry);
        }

        // GET: Admin/ProductCountries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductCountries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductCountry productCountry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCountry);
        }

        // GET: Admin/ProductCountries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCountry = await _context.ProductCountries.FindAsync(id);
            if (productCountry == null)
            {
                return NotFound();
            }
            return View(productCountry);
        }

        // POST: Admin/ProductCountries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductCountry productCountry)
        {
            if (id != productCountry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCountryExists(productCountry.Id))
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
            return View(productCountry);
        }

        // GET: Admin/ProductCountries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCountry = await _context.ProductCountries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCountry == null)
            {
                return NotFound();
            }

            return View(productCountry);
        }

        // POST: Admin/ProductCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCountry = await _context.ProductCountries.FindAsync(id);
            _context.ProductCountries.Remove(productCountry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCountryExists(int id)
        {
            return _context.ProductCountries.Any(e => e.Id == id);
        }
    }
}
