using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class Product
    {
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public decimal UnitPrice{ get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        // Calculated fields
#if WITH_CALCULATED_FIELDS
        public decimal? CartTotal { get; set; }
        public decimal? CartQuantity { get; set; }
#endif
    }
}
