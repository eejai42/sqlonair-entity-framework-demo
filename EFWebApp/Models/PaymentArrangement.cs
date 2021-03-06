using SQLonAirCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class PaymentArrangement
    {
        public Guid PaymentArrangementId { get;set;} = Guid.NewGuid();
        public int Term { get; set; } = 15;

        [SQLonAirCalculation("concat('NET ', Term)", Description = "A human readable description of the Payment Terms - e.g. NET 10")]
        public string TermName { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
