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
        [MinAllowedOrderValue]
        [MaxAllowedOrderVlaue]
        [ItemsAvailability]
        public List<int> ItemsIDs { get; set; }
        public string Address { get; set; }
        public int BuyerID { get; set; }

        //1- CARD
        //2- WALLET
        public int PaymentTypeID { get; set; }
    }
}
