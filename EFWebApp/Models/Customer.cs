using SQLonAirCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class Customer
    {
        public Guid CustomerId { get;set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public decimal? TaxRate { get; set; }

        [SQLonAirLookup(typeof(PaymentArrangement), "Term", "PaymentArrangementId", Description = "The payment arrangement that governs this customer's payment terms.")] 
        public int? PaymentTerm { get; set; }

        public Guid? PaymentArrangementId { get; set; }
        public PaymentArrangement PaymentArrangement { get; set; }

        public ICollection<Order> Orders { get; set; }

#if WITH_CALCULATED_FIELDS
        [SQLonAirCalculation("FORMAT(TaxRate, 'P2')", Description = "The customers TaxRate, formatted as a human readable percentage.")]
        public string TaxRateDisplay { get; set; }

        [SQLonAirAggregation(typeof(Order), "OrderDate", "CustomerId", Calculation = "max(values)", Description = "The date of the most recent customer order." )]
        public DateTime? LastOrderDate { get; set; }

        [SQLonAirAggregation(typeof(Order), "DueDate", "CustomerId", Calculation = "max(values)", Description = "DueDate of the most recent customer order.")]
        public DateTime? LastOrderDueDate { get; set; }

        [SQLonAirAggregation(typeof(Order), "Total", "CustomerId", Calculation = "sum(values)", Description = "Total value of all orders that the customer has placed.")]
        public decimal? OrderTotal { get; set; }

        [SQLonAirAggregation(typeof(Order), "Total", "CustomerId", "sum(values)", "IsPastDue=1", Description = "Total value of all Past Due orders that the customer has placed.")]
        public decimal? PastDueAmount { get; set; }

        [SQLonAirCalculation("IIF((OrderTotal > 100) AND (coalesce(PastDueAmount,0) = 0),1,0)", Description = "True if the customer over $100 in total orders, and NO past due balance.")]
        public bool? IsVIP { get; set; }
#endif
    }
}
