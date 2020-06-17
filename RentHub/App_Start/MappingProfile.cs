using System.Data.Entity.Migrations.Model;
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
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id,
                c => c.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, 
                m => m.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>().ForMember(g => g.Id,
                g => g.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>().ForMember(m => m.Id,
                m => m.Ignore());
        }
    }
}