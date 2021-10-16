using Microsoft.EntityFrameworkCore;
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
    public class OrderingReopsitory : IOrderingRepository
    {
        private readonly EFContext _context;
        public OrderingReopsitory(EFContext context)
        {
            _context = context;
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync(List<int> IDs)
        {
            return await _context.OrderItems.Where(x => IDs.Contains(x.ID)).ToListAsync();
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
            _ = await _context.SaveChangesAsync();
            return order.ID;
        }

        public async Task SaveItemsToOrdersAsync(int OrderId, List<int> itemsIDs)
        {
            _context.OrderItemToOrders.AddRange(itemsIDs.Select(ItemId => new OrderItemToOrder()
            {
                OrderID = OrderId,
                OrderItemID = ItemId
            }).ToList());

            _ = await _context.SaveChangesAsync();
        }
    }
}
