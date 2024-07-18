using OrderSystem.Core.Entities;

namespace OrderSystem.APIs.DTOs
{
    public class InvoiceToReturnDto
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public int OrderId { get; set; }

    }
}
