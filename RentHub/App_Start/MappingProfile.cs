using AutoMapper;
using RentHub.Dtos;
using RentHub.Models;

namespace RentHub
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}