using AutoMapper;
using Pro.Universal.Data.DataTransferObjects;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Role, RoleDto>();
        }
    }
}