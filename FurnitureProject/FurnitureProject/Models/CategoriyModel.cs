using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Models
{
    public class CategoriyModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<MarkaModel> Markas { get; set; }
        public CategoriyModel()
        {
            Markas = new HashSet<MarkaModel>();
        }
    }
}
