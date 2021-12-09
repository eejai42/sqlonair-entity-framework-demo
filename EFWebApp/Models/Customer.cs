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
        public int? PaymentTerm { get; set; }

        public Guid? PaymentArrangementId { get; set; }
        public PaymentArrangement PaymentArrangement { get; set; }

        public ICollection<Order> Orders { get; set; }

#if WITH_CALCULATED_FIELDS
        // Calculated Fields
        [SQLonAirCalculation("FORMAT(TaxRate, 'P2')")]
        public string TaxRateDisplay { get; set; }

        [SQLonAirAggregation("Order", "OrderDate", "CustomerId", Calculation = "max(values)" )]
        public DateTime? LastOrderDate { get; set; }

        [SQLonAirAggregation("Order", "DueDate", "CustomerId", Calculation = "max(values)")]
        public DateTime? LastOrderDueDate { get; set; }

        [SQLonAirAggregation("Order", "Total", "CustomerId", Calculation = "sum(values)")]
        public decimal? OrderTotal { get; set; }

        [SQLonAirAggregation("Order", "Total", "CustomerId", "sum(values)", "IsPastDue=1")]
        public decimal? PastDueAmount { get; set; }

        [SQLonAirCalculation("OrderTotal > 100 AND PastDueAmount = 0")]
        public bool? IsVIP { get; set; }
#endif
    }
}
