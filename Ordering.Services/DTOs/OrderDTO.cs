using Ordering.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.DTOs
{
    public class OrderDTO
    {
        [MinAllowedOrderValueAttribute(ErrorMessage = "Order Value Must be More Than 100 EGP")]

        public List<int> ItemsIDs { get; set; }

        public string Address { get; set; }
        public int BuyerID { get; set; }


    }
}
