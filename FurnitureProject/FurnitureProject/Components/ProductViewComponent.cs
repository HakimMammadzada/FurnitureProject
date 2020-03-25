using AutoMapper;
using FurnitureProject.Data;
using FurnitureProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Components
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly IMapper mapper;
        private readonly FurnitureDbContext context;
        public ProductViewComponent(FurnitureDbContext _context,
                                                                 IMapper _mapper)
        {
            mapper = _mapper;
            context = _context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = mapper.Map<ProductModel[]>(await context.Products.ToListAsync());
            return View(product);
        }
    }
}
