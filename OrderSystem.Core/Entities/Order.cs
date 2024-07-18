using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Core.Entities
{
    public class Order
    {
        public Order()
        {
            
        }
        public Order(int customerId, decimal totalAmount, ICollection<OrderItem> items, PaymentMethod paymentMethod)
        {
            CustomerId = customerId;
            TotalAmount = totalAmount;
            Items = items;
            PaymentMethod = paymentMethod;
        }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public decimal TotalAmount { get; set; } 

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public PaymentMethod PaymentMethod { get; set; }

    }
}
