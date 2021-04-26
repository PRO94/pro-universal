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
    }
}