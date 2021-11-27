using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class Cart
    {
        public Guid CartId { get;set; }
        public int CartNumber { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CartDate { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        // Calculated Fields
        public string CustomerName { get; set; }
        public decimal CustomerTaxRate { get; set; }
        public decimal CustomerPaymentTerm { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime DueDate { get; set; }
        public Boolean IsDue { get; set; }
    }
}
