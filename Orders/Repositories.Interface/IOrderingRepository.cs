using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Repositories.Interface
{
    public interface IOrderingRepository
    {
        Task<int> SaveChecedkOutOrderAsync(Ordering.Domain.Order.Aggregate.Order order);
    }
}
