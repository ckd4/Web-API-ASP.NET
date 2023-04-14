using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            Filters = new HashSet<Filter>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Filter> Filters { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
