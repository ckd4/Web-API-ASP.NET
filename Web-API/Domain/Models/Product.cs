using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            PriceChanges = new HashSet<PriceChange>();
            PurchaseItems = new HashSet<PurchaseItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int StockId { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public int? ProductCount { get; set; }
        public decimal? ProductPrice { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual Warehouse Stock { get; set; } = null!;
        public virtual ICollection<PriceChange> PriceChanges { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
