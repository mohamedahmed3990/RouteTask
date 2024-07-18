using OrderSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Core.Services.Contract
{
    public interface IInvoiceService
    {
        Task<IReadOnlyList<Invoice>> GetAllInvoiceAsync();

        Task<Invoice?> GetInvoiceAsync(int InvoiceId);

        Task CreateInvoiceAsync(Order order);
    }
}
