using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Models
{
    public class ProductCountryModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<ProductModel> Products { get; set; }
        public ProductCountryModel()
        {
            Products = new HashSet<ProductModel>();
        }
    }
}
