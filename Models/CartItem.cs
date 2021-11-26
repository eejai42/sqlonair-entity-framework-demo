﻿using System;
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

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        // Calculated Fields
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
