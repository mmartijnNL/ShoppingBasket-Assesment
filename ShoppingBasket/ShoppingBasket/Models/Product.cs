using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Models
{
    public class Product
    {
        [Required]        
        public int ID { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Add a name for this product.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "The Price must be bigger than 0.")]
        public decimal Price { get; set; }


        public Product()
        {  }        
    }
}
