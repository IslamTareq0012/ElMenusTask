using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.DTOs
{
    public class CheckoutOrderResponseDTO
    {
        public bool IsSuccessfullyCheckOut { get; set; }

        public string PaymentURLResponse { get; set; }
    }
}
