using System;

namespace Pro.Universal.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}