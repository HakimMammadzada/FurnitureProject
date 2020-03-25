using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FurnitureProject.Areas.Admin.Models;
using FurnitureProject.Data;
using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FurnitureProject.Controllers
{
    public class CardController : Controller
    {
        private readonly FurnitureDbContext context;
        private readonly IMapper mapper;
        public CardController(FurnitureDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add(int id)
        {
            Product product =await context.Products.FindAsync(id);
            BasketProduct basketProduct = product;
            string card = HttpContext.Session.GetString("card");
            List<BasketProduct> products = new List<BasketProduct>();
            if (card != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketProduct>>(card);
            }
            var selected = products.FirstOrDefault(x => x.Id == id);
            if (selected == null)
            {
                products.Add(product);
            }
            else
            {
                selected.Quantity++;
            }

            string productsJeson = JsonConvert.SerializeObject(products);
            HttpContext.Session.SetString("card", productsJeson);
            return RedirectToAction( "Index", "Home");
        }
    }
}