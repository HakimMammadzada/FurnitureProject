using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Data.Entities
{
    public class Categoriy
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50,MinimumLength =3)]
        public string Name { get; set; }
        public ICollection<Marka> Markas { get; set; }
        public Categoriy()
        {
            Markas= new HashSet<Marka>();
        }
    }
}
