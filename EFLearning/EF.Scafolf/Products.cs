using System;
using System.Collections.Generic;

namespace EF.Scafolf
{
    public partial class Products
    {
        public Products()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
