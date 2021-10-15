using Ordering.Domain.Order.Aggregate;
using Ordering.Domain.Repositories.Interface;
using Ordering.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.RepositoryImplementaion
{
    class OrderingReopsitory : IOrderingRepository
    {
        private readonly EFContext _context;
        public OrderingReopsitory(EFContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChecedkOutOrderAsync(Order order)
        {
            _context.Order.Add(new Order()
            {
                Address = order.Address,
                BuyerID = order.BuyerID,
                DateCreated = DateTime.Now,
                OrderTotalValue = order.OrderTotalValue,
                OrderItemToOrders = order.OrderItemToOrders
            });

          return await _context.SaveChangesAsync();
        }
    }
}
