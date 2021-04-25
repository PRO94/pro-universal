using System;
using System.Collections.Generic;

namespace Pro.Universal.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Customer> Customers { get; set; }
    }
}