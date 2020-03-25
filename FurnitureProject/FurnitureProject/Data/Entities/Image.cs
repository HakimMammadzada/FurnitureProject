using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string Photo { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
       
    }
}
