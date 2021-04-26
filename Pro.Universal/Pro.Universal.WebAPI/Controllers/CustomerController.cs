using Microsoft.AspNetCore.Mvc;
using System;
using Pro.Universal.Common.Services.Interfaces;
using Pro.Universal.Data.Repositories.Interfaces;

namespace Pro.Universal.WebAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;

        public CustomerController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repository.Customer.GetAllCustomers();

                _logger.LogInfo($"Returned all customers from database");

                return Ok(customers);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetAllCustomers action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}