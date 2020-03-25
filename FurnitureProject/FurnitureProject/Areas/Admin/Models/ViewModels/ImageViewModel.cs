using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Areas.Admin.Models.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        public List<IFormFile> Photos { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
