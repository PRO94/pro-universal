using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using Pro.Universal.Common.Services.Interfaces;
using Pro.Universal.Data.DataTransferObjects;
using Pro.Universal.Data.Repositories.Interfaces;

namespace Pro.Universal.WebAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CustomerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repository.Customer.GetAllCustomers();

                _logger.LogInfo($"Returned all customers from database");

                var customersResult = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                return Ok(customersResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetAllCustomers action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            try
            {
                var customer = _repository.Customer.GetCustomerById(id);

                if (customer == null)
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned customer with id: {id}");

                var customerResult = _mapper.Map<CustomerDto>(customer);
                return Ok(customerResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetCustomerById action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}