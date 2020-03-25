using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Areas.Admin.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public int ProductCountryId { get; set; }
        public int MarkaId { get; set; }
        [Required]
        public byte Count { get; set; }
        public int ProductDesingerId { get; set; }
        public int PropertyId { get; set; }
        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }
        [Required]
        public IFormFile Mainimage { get; set; }
        public int Discount { get; set; }
        public virtual Marka Marka { get; set; }

        public virtual ProductCountry ProductCountry { get; set; }
        public virtual ProductDesinger ProductDesinger { get; set; }
        public virtual Property Property { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ProductViewModel()
        {
            ProductColors = new HashSet<ProductColor>();
            Images = new HashSet<Image>();
        }


    }
}
