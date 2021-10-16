using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.DTOs.PaymentRequestsModel
{
    public class PayemntMethodsLookUPs
    {
        public enum IntegrationsLookUp
        {
            CARD = 223218,
            WALLET,
            CASH,
            AGGREGATOR = 224579
        }
    }
}
