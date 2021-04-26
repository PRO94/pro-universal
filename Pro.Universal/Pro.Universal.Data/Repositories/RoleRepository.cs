using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pro.Universal.Data.DbContext;
using Pro.Universal.Data.Repositories.Base;
using Pro.Universal.Data.Repositories.Interfaces;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ProUniversalContext proUniversalContext)
            : base(proUniversalContext)
        {
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return FindAll().OrderBy(r => r.Name)
                .ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return FindByCondition(r => r.Id.Equals(id))
                .FirstOrDefault();
        }

        public Role GetRoleByName(string name)
        {
            return FindByCondition(r => r.Name.Equals(name))
                .FirstOrDefault();
        }

        public Role GetRoleWithAllCustomers(Guid id)
        {
            return FindByCondition(r => r.Id.Equals(id))
                .Include(c => c.Customers)
                .FirstOrDefault();
        }

        public void CreateRole(Role role) => Create(role);

        public void UpdateRole(Role role) => Update(role);

        public void DeleteRole(Role role) => Delete(role);
    }
}