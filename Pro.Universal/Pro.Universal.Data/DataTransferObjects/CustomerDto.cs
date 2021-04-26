﻿using System;
using Pro.Universal.Data.DataTransferObjects.Base;

namespace Pro.Universal.Data.DataTransferObjects
{
    public class CustomerDto : BaseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}