using Ordering.Domain.Order.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Repositories.Interface
{
    public interface IOrderingRepository
    {
        Task<int> SaveChecedkOutOrderAsync(Ordering.Domain.Order.Aggregate.Order order);
        Task SaveItemsToOrdersAsync(int OrderId, List<int> itemsIDs);
        Task<List<OrderItem>> GetOrderItemsAsync(List<int> IDs);
    }
}
