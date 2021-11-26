using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public decimal Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } 
    }
}
