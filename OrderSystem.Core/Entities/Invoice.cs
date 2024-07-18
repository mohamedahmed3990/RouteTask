using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Core.Entities
{
    public class Invoice
    {
        public Invoice()
        {
            
        }
        public Invoice(int orderId, decimal totalAmount, Order order)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
            Order = order;
        }
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public Order Order { get; set; }
    }

    
}
