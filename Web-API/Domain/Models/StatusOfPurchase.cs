using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class StatusOfPurchase
    {
        public int PurchaseId { get; set; }
        public string? PurchaseStatus { get; set; }

        public virtual Purchase Purchase { get; set; } = null!;
    }
}
