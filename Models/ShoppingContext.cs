using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }

        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Product> Products{ get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;
    }
}
