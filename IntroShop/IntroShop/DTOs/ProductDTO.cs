using IntroShop.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroShop.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Qty { get; set; }

        public int CId { get; set; }

        public virtual Category Category { get; set; }
    }
}