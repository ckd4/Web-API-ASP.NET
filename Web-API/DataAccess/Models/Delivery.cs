using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Delivery
    {
        public int ProductId { get; set; }
        public int StockId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductCount { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Warehouse Stock { get; set; } = null!;
    }
}
