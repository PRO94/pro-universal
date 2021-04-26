using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pro.Universal.Data.DataTransferObjects.Base;
using Pro.Universal.Domain.Entities;

namespace Pro.Universal.Data.DataTransferObjects
{
    public class RoleDto : BaseDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual IEnumerable<CustomerDto> Customers { get; set; }
    }
}