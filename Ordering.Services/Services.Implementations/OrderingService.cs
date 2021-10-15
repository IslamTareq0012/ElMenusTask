using Ordering.Domain.Repositories.Interface;
using Ordering.Services.DTOs;
using Ordering.Services.Services.Interfaces;
using Ordering.Services.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.Services.Implementations
{
    public class OrderingService : IOrderingService
    {

        private readonly IOrderingRepository _repository;

        public OrderingService(IOrderingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<CheckoutOrderResponseDTO>> CrateOrderAsync(OrderDTO order)
        {
            try
            {
                var ordersItems = await _repository.GetOrderItemsAsync(order.ItemsIDs);
                var OrderId = await _repository.SaveChecedkOutOrderAsync(new Domain.Order.Aggregate.Order()
                {
                    Address = order.Address,
                    OrderTotalValue = ordersItems.Sum(x => x.ItemPrice),
                    BuyerID = order.BuyerID
                });

                await _repository.SaveItemsToOrdersAsync(OrderId, ordersItems.Select(x => x.ID).ToList());
                return new Response<CheckoutOrderResponseDTO>(new CheckoutOrderResponseDTO()
                {
                    IsSuccessfullyCheckOut = true
                });
            }
            catch (Exception e)
            {
                return new Response<CheckoutOrderResponseDTO>("Error-1001");
            }
        }
    }
}
