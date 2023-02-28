using System;
using System.Collections.Generic;

namespace EF.Scafolf
{
    public partial class OrderItems
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int NumberOfItems { get; set; }
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
