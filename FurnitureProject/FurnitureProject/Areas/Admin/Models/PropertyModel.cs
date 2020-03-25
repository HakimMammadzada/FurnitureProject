using FurnitureProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Areas.Admin.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }
        public ICollection<Product> Products { get; set; }
        public PropertyModel()
        {
            Products = new HashSet<Product>();
        }
    }
}
