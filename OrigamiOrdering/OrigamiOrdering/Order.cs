using System;
using System.Collections.Generic;

#nullable disable

namespace OrigamiOrdering
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? ModelId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Model Model { get; set; }
    }
}
