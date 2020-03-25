using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FurnitureProject.Models;
using FurnitureProject.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace FurnitureProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly FurnitureDbContext context;
        private readonly IMapper mapper;
        public HomeController(FurnitureDbContext _context,IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await context.Products.ToListAsync();
            var mapperproducts = mapper.Map<ProductModel[]>(products);
            return View(mapperproducts);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
