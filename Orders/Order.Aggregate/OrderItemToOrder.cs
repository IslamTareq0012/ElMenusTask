using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Order.Aggregate
{
    public class OrderItemToOrder
    {
        public int OrderID { get; set; }

        public Order Order { get; set; }
        public int OrderItemID { get; set; }

        public OrderItem OrderItem { get; set; }
    }
}
