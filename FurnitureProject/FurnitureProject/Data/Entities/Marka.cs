using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Data.Entities
{
    public class Marka
    {
        public int Id { get; set; }
        public int CategoriyId { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        public Categoriy Categoriy { get; set; }
        public ICollection<Product> Products { get; set; }
        public Marka()
        {
            Products = new HashSet<Product>();
        }

    }
}
