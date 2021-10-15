using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Order.Aggregate
{
    public class Order
    {
        public int ID { get; set; }

        public string Address { get; set; }

        public DateTime DateCreated { get; set; }

        public int BuyerID { get; set; }

        public decimal OrderTotalValue { get; set; }
        public IList<OrderItemToOrder> OrderItemToOrders { get; set; }

    }
}
