using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShoppingBasket.Models
{
    public class ShoppingBasketContext : DbContext
    {
        public ShoppingBasketContext() { }

        public ShoppingBasketContext (DbContextOptions<ShoppingBasketContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingBasket.Models.Product> Product { get; set; }
    }
}
