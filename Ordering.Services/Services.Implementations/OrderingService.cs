using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories.Interface;
using Ordering.Services.DTOs;
using Ordering.Services.Payment.Services;
using Ordering.Services.Services.Interfaces;
using Ordering.Services.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.Services.Implementations
{
    public class OrderingService : IOrderingService
    {

        private readonly IOrderingRepository _repository;
        public readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHttpClientFactory _clientFactory;

        public OrderingService(IOrderingRepository repository,
            IServiceScopeFactory serviceScopeFactory,
            IHttpClientFactory clientFactory)
        {
            _repository = repository;
            _serviceScopeFactory = serviceScopeFactory;
            _clientFactory = clientFactory;

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

                using (var serviceScope = _serviceScopeFactory.CreateScope())
                {
                    switch (order.PaymentTypeID)
                    {
                        case 1:

                            //CARD PAYMENT
                            var CardPaymentService = serviceScope.ServiceProvider.GetService<CardPayment>();
                            var CardPaymentServiceResult = await CardPaymentService.PayAsync(new DTOs.PaymentRequestsModel.OrderRegistrationRequest()
                            {
                                amount_cents = (int)ordersItems.Sum(x => x.ItemPrice) * 1000,
                                delivery_needed = "false",
                                currency = "EGP",
                                paymentRequest = new DTOs.PaymentRequestsModel.PaymentRequest()
                                {
                                    source = new DTOs.PaymentRequestsModel.PaymentRequest.PaymentSource()
                                    {
                                        subtype = "CARD"
                                    }
                                },
                                items = new List<DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems>() { new DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems() {
                                    amount_cents = ((int)ordersItems.Sum(x => x.ItemPrice) * 1000).ToString(),
                                    quantity = 1,
                                    name = "ORDER ID : " + OrderId.ToString()
                                } }
                            }, _clientFactory.CreateClient());

                            return new Response<CheckoutOrderResponseDTO>(new CheckoutOrderResponseDTO()
                            {
                                IsSuccessfullyCheckOut = true,
                                PaymentURLResponse = CardPaymentServiceResult
                            });
                        case 2:
                            var WalletPaymentService = serviceScope.ServiceProvider.GetService<WalletPayment>();
                            var WalletPaymentServiceResult = await WalletPaymentService.PayAsync(new DTOs.PaymentRequestsModel.OrderRegistrationRequest()
                            {
                                amount_cents = (int)ordersItems.Sum(x => x.ItemPrice) * 1000,
                                delivery_needed = "false",
                                currency = "EGP",
                                paymentRequest = new DTOs.PaymentRequestsModel.PaymentRequest()
                                {
                                    source = new DTOs.PaymentRequestsModel.PaymentRequest.PaymentSource()
                                    {
                                        subtype = "CARD"
                                    }
                                },
                                items = new List<DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems>() { new DTOs.PaymentRequestsModel.OrderRegistrationRequest.RequestItems() {
                                    amount_cents = ((int)ordersItems.Sum(x => x.ItemPrice) * 1000).ToString(),
                                    quantity = 1,
                                    name = "ORDER ID : " + OrderId.ToString()
                                } }
                            }, _clientFactory.CreateClient());

                            return new Response<CheckoutOrderResponseDTO>(new CheckoutOrderResponseDTO()
                            {
                                IsSuccessfullyCheckOut = true,
                                PaymentURLResponse = WalletPaymentServiceResult
                            });

                        default:
                            break;
                    }
                }
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
