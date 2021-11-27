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

        public ICollection<Customer> Customer { get; set; }

#if WITH_CALCULATED_FIELDS
        public string TermName { get; set; } = "NET 15"
#endif
    }
}
