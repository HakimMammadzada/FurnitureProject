using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Areas.Admin.Models
{
    public class ProductColorModel
    {
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public ColorModel Color { get; set; }
        public ProductModel Product { get; set; }
    }
}
