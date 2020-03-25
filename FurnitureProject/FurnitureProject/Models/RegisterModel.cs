using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 30, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

    }
}
