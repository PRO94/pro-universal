using System;
using System.Collections.Generic;
using Pro.Universal.Data.Repositories.Interfaces.Base;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.Data.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(Guid customerId);
        void CreateCustomer(Customer customer);
    }
}