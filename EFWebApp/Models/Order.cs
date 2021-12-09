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
        // Calculated Fields
        [SQLonAirLookup("Customer", "Name", "CustomerId")]
        public string CustomerName { get; set; }

        [SQLonAirLookup("Customer", "PaymentTerm", "CustomerId")]
        public int? CustomerPaymentTerm { get; set; }
        
        [SQLonAirLookup("Customer", "PhoneNumber", "CustomerId")]
        public string CustomerPhoneNumber { get; set; }

        [SQLonAirLookup("Customer", "TaxRateDisplay", "CustomerId")]
        public string CustomerTaxRateDisplay { get; set; }

        [SQLonAirLookup("Customer", "TaxRate", "CustomerId", Precision=4)]
        public decimal? CustomerTaxRate { get; set; }

        [SQLonAirAggregation("LineItem", "SubTotal", "OrderId")]
        public decimal? SubTotal { get; set; }

        [SQLonAirCalculation("SubTotal * TaxRate")]
        public decimal? Tax { get; set; }

        [SQLonAirCalculation("SubTotal + Tax")]
        public decimal? Total { get; set; }
        
        [SQLonAirCalculation("DATE_ADD(DAY, DueDate, CustomerPaymentTerm)")]
        public DateTime? DueDate { get; set; }

        [SQLonAirCalculation("IIF(getdate() > DueDate, 1, 0)")]
        public Boolean? IsPastDue { get; set; }
#endif
    }
}
