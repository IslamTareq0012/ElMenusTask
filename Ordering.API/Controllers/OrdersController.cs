using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Services.DTOs;
using Ordering.Services.Services.Implementations;
using Ordering.Services.Services.Interfaces;
using Ordering.Services.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderingService _orderingService;
        public OrdersController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }
        [HttpPost("CheckOutOrder")]
        public async Task<Response<CheckoutOrderResponseDTO>> CheckOutOrderAsync(OrderDTO order)
        {
            return await _orderingService.CrateOrderAsync(order);
        }
    }
}
