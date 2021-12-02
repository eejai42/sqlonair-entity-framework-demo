﻿using System;
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
        public decimal? OrderTotal { get; set; }
        public decimal? PastDueAmount { get; set; }
        public bool? IsVIP { get; set; }
#endif
    }
}
