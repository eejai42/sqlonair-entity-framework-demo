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
        [SQLonAirLookup(typeof(Order), "CustomerName", "OrderId", Description = "Name of the customer linked to this Line Item's related order.")]
        public string CustomerName { get; set; }

        [SQLonAirLookup(typeof(Product), "Name", "ProductId", Description = "Name of the product linked to this Line Item.")]
        public string ProductName { get; set; }
        
        [SQLonAirLookup(typeof(Order), "CustomerTaxRateDisplay", "OrderId", Description = "Human Readable TaxRate for the given customer, formatted as a percentage.")]
        public string CustomerTaxRateDisplay { get; set; }

        [SQLonAirLookup(typeof(Product), "UnitPrice", "ProductId", Description = "The unit price of the product linked to this LineItem.")]
        public decimal? UnitPrice { get; set; }

        [SQLonAirCalculation("Quantity * UnitPrice", Description = "The SubTotal of the LineItem using UnitPrice and Quantity.")]
        public decimal? SubTotal { get; set; }

        [SQLonAirLookup(typeof(Order), "CustomerTaxRate", "OrderId", Precision = 4, Description = "The decimal value of the tax rate for the customer linked to the associated order.")]
        public decimal? CustomerTaxRate { get; set; }

        [SQLonAirCalculation("SubTotal * CustomerTaxRate", Description = "The Tax, calculated using the subtotal and customer's tax rate.")]
        public decimal? Tax { get; set; }

        [SQLonAirCalculation("SubTotal + Tax", Description = "The Line ITem total, including both the subtotal and the calcualted tax due.")]
        public decimal? Total { get; set; }
#endif
    }
}
