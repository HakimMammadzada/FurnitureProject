using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Models
{
    public class ImageModel
    {
        [Required]
        public string Photo { get; set; }
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }
       
    }
}
