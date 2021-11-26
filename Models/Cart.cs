using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class Cart
    {
        public Guid CartId { get;set; }
        public int CartNumber { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
