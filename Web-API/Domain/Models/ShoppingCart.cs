using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ShoppingCart
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int? ProductCount { get; set; }
        public decimal? ProductPrice { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
