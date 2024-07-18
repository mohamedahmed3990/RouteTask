using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.APIs.DTOs;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Services.Contract;

namespace OrderSystem.APIs.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(int orderId)
        {
            var order = await _orderService.GetOrder(orderId);
            if (order == null)
                return BadRequest();

            return Ok(order);
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();

            var mappedOrder = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders);
            return Ok(mappedOrder);
        }


        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            var createdOrder = await _orderService.CreateOrder(order);
            if (createdOrder == null)
                return BadRequest();

            return createdOrder;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            await _orderService.UpdateOrderStatus(orderId, status);
            return Ok("Status Updated successfuly");
        }
    }
}
