using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FurnitureProject.Data;
using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using FurnitureProject.Areas.Admin.Models.ViewModels;
using System.IO;

namespace FurnitureProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly FurnitureDbContext _context;
        private readonly IWebHostEnvironment environment;

        public ProductsController(FurnitureDbContext context,IWebHostEnvironment _environment)
        {
            _context = context;
            environment = _environment;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var furnitureDbContext = _context.Products.Include(p => p.Marka).Include(p => p.ProductCountry).Include(p => p.ProductDesinger).Include(p => p.Property);
            return View(await furnitureDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Marka)
                .Include(p => p.ProductCountry)
                .Include(p => p.ProductDesinger)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["MarkaId"] = new SelectList(_context.Markas, "Id", "Name");
            ViewData["ProductCountryId"] = new SelectList(_context.ProductCountries, "Id", "Name");
            ViewData["ProductDesingerId"] = new SelectList(_context.productDesingers, "Id", "Name");
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Size");
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ProductViewModel product)
        {
         
            if (ModelState.IsValid)
            {
                string uploadFilename = UploadFiles(product);
                Product newproduct = new Product
                {
                    Mainimage = uploadFilename,
                    Discount = product.Discount,
                    Count = product.Count,
                    Name = product.Name,
                    MarkaId = product.MarkaId,
                    ProductCountryId = product.ProductCountryId,
                    ProductDesingerId = product.ProductDesingerId,
                    PropertyId = product.PropertyId,
                    Price=product.Price
                };
                _context.Add(newproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarkaId"] = new SelectList(_context.Markas, "Id", "Name", product.MarkaId);
            ViewData["ProductCountryId"] = new SelectList(_context.ProductCountries, "Id", "Name", product.ProductCountryId);
            ViewData["ProductDesingerId"] = new SelectList(_context.productDesingers, "Id", "Name", product.ProductDesingerId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Size", product.PropertyId);
            return View(product);
        }
        private string UploadFiles(ProductViewModel model)
        {
            string uniqueFileName = null;
            if (model.Mainimage != null)
            {
                string uploadesFolder = Path.Combine(environment.WebRootPath, @"images/product");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Mainimage.FileName;
                string filePath = Path.Combine(uploadesFolder, uniqueFileName);
                model.Mainimage.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            return uniqueFileName;
        }
        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["MarkaId"] = new SelectList(_context.Markas, "Id", "Name", product.MarkaId);
            ViewData["ProductCountryId"] = new SelectList(_context.ProductCountries, "Id", "Name", product.ProductCountryId);
            ViewData["ProductDesingerId"] = new SelectList(_context.productDesingers, "Id", "Name", product.ProductDesingerId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Size", product.PropertyId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductCountryId,MarkaId,Count,ProductDesingerId,PropertyId,Price,Mainimage,Discount")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["MarkaId"] = new SelectList(_context.Markas, "Id", "Name", product.MarkaId);
            ViewData["ProductCountryId"] = new SelectList(_context.ProductCountries, "Id", "Name", product.ProductCountryId);
            ViewData["ProductDesingerId"] = new SelectList(_context.productDesingers, "Id", "Name", product.ProductDesingerId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Size", product.PropertyId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Marka)
                .Include(p => p.ProductCountry)
                .Include(p => p.ProductDesinger)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
