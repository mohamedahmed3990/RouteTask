using AutoMapper;
using OrderSystem.APIs.DTOs;
using OrderSystem.Core.Entities;

namespace OrderSystem.APIs.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();

            CreateMap<Product, ProductToReturnDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.Name));
    
        }
    }
}
