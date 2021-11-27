using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class Customer
    {
        public Guid CustomerId { get;set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public decimal TaxRate { get; set; }
        public int PaymentTerm { get; set; }

        public Guid? PaymentArrangementId { get; set; }
        public PaymentArrangement PaymentArrangement { get; set; }

        public ICollection<Cart> Carts { get; set; }
 
        // Calculated Fields
        public decimal CartTotal { get; set; }
        public bool IsVIP { get; set; }
        public int PaymentArrangementTerm { get; set; }
    }
}
