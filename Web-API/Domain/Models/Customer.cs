using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int CustomerId { get; set; }
        public string CustomerPhone { get; set; } = null!;
        public string CustomerPassword { get; set; } = null!;
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerAddress { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
