using OrderSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Core.Services.Contract
{
    public interface ICustomerService
    {
        Task<Customer?> AddCustomer(Customer customer); 

        Task<IReadOnlyList<Customer>> GetAllCustomers();
    }
}
