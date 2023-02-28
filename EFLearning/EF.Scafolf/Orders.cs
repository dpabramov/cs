using System;
using System.Collections.Generic;

namespace EF.Scafolf
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Discount { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
