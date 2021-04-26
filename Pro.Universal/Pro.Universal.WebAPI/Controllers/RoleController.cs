using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using Pro.Universal.Common.Services.Interfaces;
using Pro.Universal.Data.DataTransferObjects;
using Pro.Universal.Data.Repositories.Interfaces;

namespace Pro.Universal.WebAPI.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public RoleController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/role
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            try
            {
                var roles = _repository.Role.GetAllRoles();

                _logger.LogInfo($"Returned all roles from database");

                var rolesResult = _mapper.Map<IEnumerable<RoleDto>>(roles);

                return Ok(rolesResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetAllRoles action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/role/5
        [HttpGet("{id}")]
        public IActionResult GetRoleById(Guid id)
        {
            try
            {
                var role = _repository.Role.GetRoleById(id);

                if (role == null)
                {
                    _logger.LogError($"Role with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned role with id: {id}");

                var roleResult = _mapper.Map<RoleDto>(role);
                return Ok(roleResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetRoleById action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/role/5/customers
        [HttpGet("{id}/customers")]
        public IActionResult GetRoleByIdWithCustomers(Guid id)
        {
            try
            {
                var roleWithCustomers = _repository.Role.GetRoleWithAllCustomers(id);

                _logger.LogInfo($"Returned role with customers from database");

                var roleResult = _mapper.Map<RoleDto>(roleWithCustomers);

                return Ok(roleResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetRoleByIdWithCustomers action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}