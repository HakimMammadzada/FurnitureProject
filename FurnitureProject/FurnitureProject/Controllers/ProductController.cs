using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FurnitureProject.Data;
using FurnitureProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FurnitureProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly FurnitureDbContext context;
        private readonly IMapper mapper;
        public ProductController(FurnitureDbContext _context
                                                    ,IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var product =await context.Products.Include("Marka").Include("Marka.Categoriy").ToListAsync();
            var mapproduct = mapper.Map<ProductModel[]>(product);

            return View(mapproduct);
        }


        public async Task<IActionResult> DetailProduct(int id)
        {
            var product = await context.Products
                                    .Include(x=>x.Images)
                                .Include("ProductColors")
                                .Include("ProductColors.Color").FirstOrDefaultAsync(x => x.Id == id);
            var map = mapper.Map<ProductModel>(product);
            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> GetMarkaById(int id)
        {
            var product = await context.Products.Where(x=>x.MarkaId==id).ToListAsync();
            var mapperproducts = mapper.Map<ProductModel[]>(product);
            return PartialView("_ProductPartialView", mapperproducts);
        }

        public IActionResult CategoriyProduct()
        {
            return View();
        }
    }
}
