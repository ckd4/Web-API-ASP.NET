using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchaseItems = new HashSet<PurchaseItem>();
        }

        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
