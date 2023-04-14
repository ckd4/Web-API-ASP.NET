using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Products = new HashSet<Product>();
        }

        public int StockId { get; set; }
        public string StockAddress { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
