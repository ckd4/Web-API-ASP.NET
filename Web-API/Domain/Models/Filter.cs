using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Filter
    {
        public int CategoryId { get; set; }
        public int FilterId { get; set; }
        public string FilterName { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
    }
}
