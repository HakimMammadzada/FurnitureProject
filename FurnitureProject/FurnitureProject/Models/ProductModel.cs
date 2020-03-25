using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public int ProductCountryId { get; set; }
        public int MarkaId { get; set; }
        [Required]
        public byte Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductDesingerId { get; set; }
        public int PropertyId { get; set; }
        public decimal Price { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Mainimage { get; set; }
        public int Discount { get; set; }
        public virtual ProductCountryModel ProductCountry { get; set; }
        public virtual MarkaModel MarkaModel { get; set; }
        public virtual ProductDesingerModel ProductDesinger { get; set; }
        public virtual PropertyModel Property { get; set; }
        public ICollection<ImageModel> Images { get; set; }
        public ICollection<ProductColorModel> ProductColors { get; set; }
        public ProductModel()
        {
            ProductColors = new HashSet<ProductColorModel>();
            Images = new HashSet<ImageModel>();
            this.CreatedDate = DateTime.UtcNow;

        }


    }
}
