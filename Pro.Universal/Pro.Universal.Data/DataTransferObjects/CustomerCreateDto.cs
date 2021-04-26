using System;
using System.ComponentModel.DataAnnotations;
using Pro.Universal.Data.DataTransferObjects.Base;

namespace Pro.Universal.Data.DataTransferObjects
{
    public class CustomerCreateDto : BaseDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}