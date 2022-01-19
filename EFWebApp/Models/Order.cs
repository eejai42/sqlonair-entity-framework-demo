using SQLonAirCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class Order
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int? OrderNumber { get; set; }

        public ICollection<LineItem> LineItems { get; set; }

#if WITH_CALCULATED_FIELDS
        [SQLonAirLookup(typeof(Customer), "Name", "CustomerId", Description = "Lookup to the name of the customer associated with this order.")]
        public string CustomerName { get; set; }

        [SQLonAirLookup(typeof(Customer), "PaymentTerm", "CustomerId", Description = "The PaymentTerm which this customer is subject to.")]
        public int? CustomerPaymentTerm { get; set; }
        
        [SQLonAirLookup(typeof(Customer), "PhoneNumber", "CustomerId", Description = "The phone number of the customer assocaited with this order.")]
        public string CustomerPhoneNumber { get; set; }

        [SQLonAirLookup(typeof(Customer), "TaxRateDisplay", "CustomerId", Description = "The Human Readable TaxRate formatted as a percentage.")]
        public string CustomerTaxRateDisplay { get; set; }

        [SQLonAirLookup(typeof(Customer), "TaxRate", "CustomerId", Precision=4, Description = "The tax rate as a decimal number which can be used in calculations.")]
        public decimal? CustomerTaxRate { get; set; }

        [SQLonAirAggregation(typeof(LineItem), "SubTotal", "OrderId", Description = "The Subtotal of all line items in this order.")]
        public decimal? SubTotal { get; set; }

        [SQLonAirAggregation(typeof(LineItem), "Tax", "OrderId", Description = "A sum of the Tax associated with any taxable line items in the order.")]
        public decimal? Tax { get; set; }

        [SQLonAirCalculation("SubTotal + Tax", Description = "SubTotal for all line items in the order.")]
        public decimal? Total { get; set; }
        
        [SQLonAirCalculation("DATEADD(DAY, CustomerPaymentTerm, OrderDate)", Description = "The date that this order is due, based on the PaymentArrangement/Terms for the customer linked to the order.")]
        public DateTime? DueDate { get; set; }

        [SQLonAirCalculation("IIF(getdate() > DueDate, 1, 0)", Description = "TRUE if the order has passed it's DueDate.")]
        public Boolean? IsPastDue { get; set; }
#endif
    }
}
