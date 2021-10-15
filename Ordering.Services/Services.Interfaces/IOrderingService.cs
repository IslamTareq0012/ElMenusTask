using Ordering.Services.DTOs;
using Ordering.Services.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.Services.Interfaces
{
    public interface IOrderingService
    {
        Task<Response<CheckoutOrderResponseDTO>> CrateOrderAsync(OrderDTO order);
    }
}
