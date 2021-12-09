using SQLonAirCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class LineItem
    {
        public Guid LineItemId { get; set; } = Guid.NewGuid();
        public decimal Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

#if WITH_CALCULATED_FIELDS
        [SQLonAirLookup(typeof(Order), "CustomerName", "OrderId")]
        public string CustomerName { get; set; }

        [SQLonAirLookup(typeof(Product), "Name", "ProductId")]
        public string ProductName { get; set; }
        
        [SQLonAirLookup(typeof(Order), "CustomerTaxRateDisplay", "OrderId")]
        public string CustomerTaxRateDisplay { get; set; }

        [SQLonAirLookup(typeof(Product), "UnitPrice", "ProductId")]
        public decimal? UnitPrice { get; set; }

        [SQLonAirCalculation("Quantity * UnitPrice")]
        public decimal? SubTotal { get; set; }

        [SQLonAirLookup(typeof(Order), "CustomerTaxRate", "OrderId", Precision = 4)]
        public decimal? CustomerTaxRate { get; set; }

        [SQLonAirCalculation("SubTotal * CustomerTaxRate")]
        public decimal? Tax { get; set; }

        [SQLonAirCalculation("SubTotal + Tax")]
        public decimal? Total { get; set; }
#endif
    }
}
