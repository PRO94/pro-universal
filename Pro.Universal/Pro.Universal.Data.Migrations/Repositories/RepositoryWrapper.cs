using Pro.Universal.Data.DbContext;
using Pro.Universal.Data.Repositories.Interfaces;

namespace Pro.Universal.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ProUniversalContext _proUniversalContext;
        private ICustomerRepository _customer;
        private IRoleRepository _role;

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null) _customer = new CustomerRepository(_proUniversalContext);
                return _customer;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null) _role = new RoleRepository(_proUniversalContext);
                return _role;
            }
        }

        public RepositoryWrapper(ProUniversalContext proUniversalContext)
        {
            _proUniversalContext = proUniversalContext;
        }

        public void Save()
        {
            _proUniversalContext.SaveChanges();
        }
    }
}