using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Areas.Admin.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }
    }
}
