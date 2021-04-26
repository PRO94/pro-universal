using AutoMapper;
using Pro.Universal.Data.DataTransferObjects;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ----- DataBaseModels to DataTransferObjects -----
            CreateMap<Customer, CustomerDto>();
            CreateMap<Role, RoleDto>();

            // ----- DataTransferObjects to DataBaseModels -----
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
        }
    }
}