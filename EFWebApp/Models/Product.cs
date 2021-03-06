using SQLonAirCore.Attributes;
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

        public ICollection<LineItem> LineItems { get; set; }

#if WITH_CALCULATED_FIELDS
        [SQLonAirAggregation(typeof(LineItem), "Total", "ProductId", Description = "A subtotal of all line items linked to this product.")]
        public decimal? OrderTotal { get; set; }

        [SQLonAirAggregation(typeof(LineItem), "Quantity", "ProductId", Description = "A sum of the quantities from line items linked to this product.")]
        public decimal? OrderQuantity { get; set; }
#endif
    }
}
