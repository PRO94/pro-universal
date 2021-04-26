using System;
using System.Collections.Generic;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.Data.DataTransferObjects
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<CustomerDto> Customers { get; set; }
    }
}