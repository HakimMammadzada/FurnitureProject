using AutoMapper;
using FurnitureProject.Areas.Admin.Models;
using FurnitureProject.Data;
using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Components
{
    public class CardViewComponent:ViewComponent
    {
        private readonly FurnitureDbContext context;
        private readonly IMapper mapper;
        public CardViewComponent(FurnitureDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
          string card= HttpContext.Session.GetString("card");
            List<BasketProduct> products = new List<BasketProduct>();
            if (card != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketProduct>>(card);
            }
            return View(products);
        }
    }
}
