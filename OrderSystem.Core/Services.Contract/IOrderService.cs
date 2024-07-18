using OrderSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Core.Services.Contract
{
    public interface IOrderService
    {
        Task<Order?> CreateOrder(Order order);

        Task<Order?> GetOrder(int orderId);

        Task<IReadOnlyList<Order>> GetAllOrders();

        Task UpdateOrderStatus(int orderId, OrderStatus orderStatus);
    }
}
