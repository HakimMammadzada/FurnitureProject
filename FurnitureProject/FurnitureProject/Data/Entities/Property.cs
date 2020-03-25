using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Data.Entities
{
    public class Property
    {
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }
        public ICollection<Product> Products { get; set; }
        public Property()
        {
            Products = new HashSet<Product>();
        }
    }
}