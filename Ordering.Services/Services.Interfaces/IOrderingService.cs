using Ordering.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.Services.Interfaces
{
    public interface IOrderingService
    {
        Task<bool> CrateOrderAsync(OrderDTO order);
    }
}
