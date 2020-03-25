using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Data.Entities
{
    public class BasketProduct
    {
        public int Id { get; set; }
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
        public string Mainimage { get; set; }
        public int Discount { get; set; }
        public virtual Marka Marka { get; set; }
        public int Quantity { get; set; }
        public virtual ProductCountry ProductCountry { get; set; }
        public virtual ProductDesinger ProductDesinger { get; set; }
        public virtual Property Property { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public DateTime CreatedDate { get; set; }


        public BasketProduct()
        {
            ProductColors = new HashSet<ProductColor>();
            Images = new HashSet<Image>();
            this.CreatedDate = DateTime.UtcNow;

        }
    }
}
