using System;
using System.Collections.Generic;
using Pro.Universal.Data.Repositories.Interfaces.Base;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.Data.Repositories.Interfaces
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(Guid id);
        Role GetRoleByName(string name);
        Role GetRoleWithAllCustomers(Guid id);
    }
}