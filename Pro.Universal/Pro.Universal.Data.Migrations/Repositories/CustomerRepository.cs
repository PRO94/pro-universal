﻿using Pro.Universal.Data.DbContext;
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
    }
}