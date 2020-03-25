﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Models
{
    public class ColorModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<ProductColorModel> ProductColors { get; set; }
        public ColorModel()
        {
            ProductColors = new HashSet<ProductColorModel>();
        }
    }
}
