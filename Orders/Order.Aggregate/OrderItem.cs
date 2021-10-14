using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Order.Aggregate
{
    public class OrderItem
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public bool  isValid { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
