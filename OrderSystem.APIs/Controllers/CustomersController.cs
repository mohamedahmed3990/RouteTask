using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.APIs.DTOs;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Repository.Contract;
using OrderSystem.Core.Services.Contract;

namespace OrderSystem.APIs.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto customerDto)
        {
            var mappedCustomer = _mapper.Map<CustomerDto, Customer>(customerDto);
            var customer = await _customerService.AddCustomer(mappedCustomer);

            if (customer is null)
                return BadRequest();

            return Ok(customerDto);
        }



        //[HttpGet]
        //public async Task<ActionResult> GetAllCustomer()
        //{
        //     var customer = await _customerService.GetAllCustomers();

        //    return Ok(customer);
        //}


    }
}
