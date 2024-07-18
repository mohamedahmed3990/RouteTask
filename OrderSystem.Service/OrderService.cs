using OrderSystem.Core;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public OrderService(IUnitOfWork unitOfWork, IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<Order?> CreateOrder(Order order)
        {
            // 1. Validate order to check of product stock
            var validateResult = await ValidateProductStock(order);

            if (validateResult is true)
            {


                // 2. calculate TotalAmount of order
                var totalAmount = CalculateTotalAmount(order);

                // 3. ApplyDiscounts
                ApplyDiscounts(order);

                // 4. Update stock
                await UpdateStock(order);

                var createdOrder = new Order(order.CustomerId, totalAmount, order.Items, order.PaymentMethod);

                await _invoiceService.CreateInvoiceAsync(createdOrder);

                return createdOrder;
            }
            else
                return null;

        }



        public async Task<Order?> GetOrder(int orderId)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(orderId);
            return order;
        }


        public async Task<IReadOnlyList<Order>> GetAllOrders()
        {
            var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
            return orders;
        }


        public async Task UpdateOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            order.Status = orderStatus;
             _unitOfWork.Repository<Order>().Update(order);
            await _unitOfWork.CompleteAsync();
        }




        private async Task<bool> ValidateProductStock(Order order)
        {
            foreach (var item in order.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.ProductId);

                if (product?.Stock < item.Quantity)
                    return false;                     
            }
            return true;
        }

        private void ApplyDiscounts(Order order)
        {
            if (order.TotalAmount > 100)
                order.TotalAmount *= .5M;

            else if (order.TotalAmount > 200)
                order.TotalAmount *= .10M;
        }

        private decimal CalculateTotalAmount(Order order)
        {
            decimal totalAmount = 0;
            foreach (var item in order.Items)
            {
                totalAmount += (item.UnitPrice * item.Discount) * item.Quantity;
            }

            return totalAmount;
        }

        private async Task UpdateStock(Order order)
        {
            foreach (var item in order.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.ProductId);
                product.Stock -= item.Quantity;
                 _unitOfWork.Repository<Product>().Update(product);

                await _unitOfWork.CompleteAsync();
            }
        }

    }
}
