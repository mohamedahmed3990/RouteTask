using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Services.Contract;

namespace OrderSystem.APIs.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Invoice>>> Getallinvoices()
        {
            var Invoices = await _invoiceService.GetAllInvoiceAsync();
            return Ok(Invoices);
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<Invoice>> GetInvoiceDetails(int invoiceId)
        {
            var invoice = await _invoiceService.GetInvoiceAsync(invoiceId);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
          
        }
    }
}
