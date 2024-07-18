using OrderSystem.Core.Entities;

namespace OrderSystem.APIs.DTOs
{
    public class OrderToReturnDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTimeOffset OrderDate { get; set; } 
        public decimal TotalAmount { get; set; } 

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        public string Status { get; set; }
        public string PaymentMethod { get; set; }
    }
}
