using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Areas.Admin.Models
{
    public class MarkaModel
    {
        public int Id { get; set; }
        public int CategoriyId { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        public CategoriyModel Categoriy { get; set; }
        public ICollection<ProductModel> Products { get; set; }
        public MarkaModel()
        {
            Products = new HashSet<ProductModel>();
        }
    }
}
