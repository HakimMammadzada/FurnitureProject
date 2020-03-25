using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Data
{
    public class FurnitureDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public FurnitureDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Categoriy> Categoriys { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductCountry> ProductCountries { get; set; }
        public DbSet<ProductDesinger> productDesingers { get; set; }
       // public DbSet<Slider> Sliders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
