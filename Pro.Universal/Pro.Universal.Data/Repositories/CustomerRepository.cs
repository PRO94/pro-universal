using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Universal.Data.DbContext;
using Pro.Universal.Data.Repositories.Base;
using Pro.Universal.Data.Repositories.Interfaces;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProUniversalContext proUniversalContext)
            : base(proUniversalContext)
        {
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return FindAll()
                .OrderBy(c => c.FirstName)
                .ToList();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            return FindByCondition(c => c.Id.Equals(customerId))
                .FirstOrDefault();
        }
    }
}