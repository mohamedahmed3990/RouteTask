using OrderSystem.Core;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<Invoice>> GetAllInvoiceAsync()
        {
            var Invoices = await _unitOfWork.Repository<Invoice>().GetAllAsync();
            return Invoices;
        }

        public async Task<Invoice?> GetInvoiceAsync(int InvoiceId)
        {
            var invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(InvoiceId);         
            return invoice;
        }


        public async Task CreateInvoiceAsync(Order order)
        {
            var invoice = new Invoice(order.OrderId, order.TotalAmount, order);

            await _unitOfWork.Repository<Invoice>().AddAsync(invoice);
            await _unitOfWork.CompleteAsync();
        }
    }
}
