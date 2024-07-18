using OrderSystem.Core;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Repository.Contract;
using OrderSystem.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Customer?> AddCustomer(Customer customer)
        {
             await _unitOfWork.Repository<Customer>().AddAsync(customer);
             var result = await _unitOfWork.CompleteAsync();
            if (result <= 0)
                return null;
            else
                return customer;
        }

        public Task<IReadOnlyList<Customer>> GetAllCustomers()
        {
            return _unitOfWork.Repository<Customer>().GetAllAsync();
        }
    }
}
