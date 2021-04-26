﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using Pro.Universal.Common.Services.Interfaces;
using Pro.Universal.Data.DataTransferObjects;
using Pro.Universal.Data.Repositories.Interfaces;
using Pro.Universal.Domain.Entities;
using Pro.Universal.WebAPI.ActionFilters;

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
            var roles = _repository.Role.GetAllRoles();

            _logger.LogInfo($"Returned all roles from database");

            var rolesResult = _mapper.Map<IEnumerable<RoleDto>>(roles);

            return Ok(rolesResult);
        }

        // GET api/role/5
        [HttpGet("{id}", Name = "RoleById")]
        public IActionResult GetRoleById(Guid id)
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

        // GET api/role/5/customers
        [HttpGet("{id}/customers")]
        public IActionResult GetRoleByIdWithCustomers(Guid id)
        {
            var roleWithCustomers = _repository.Role.GetRoleWithAllCustomers(id);

            _logger.LogInfo($"Returned role with customers from database");

            var roleResult = _mapper.Map<RoleDto>(roleWithCustomers);

            return Ok(roleResult);
        }

        // POST api/role
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateRole([FromBody] RoleCreateDto role)
        {
            var roleEntity = _mapper.Map<Role>(role);
                _repository.Role.CreateRole(roleEntity);
                _repository.Save();

            var createdRole = _mapper.Map<RoleDto>(roleEntity);

            return CreatedAtRoute("RoleById", new {id = createdRole.Id}, createdRole);
        }

        // PUT api/role/{id}
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateRole(Guid id, [FromBody] RoleUpdateDto role)
        {
            var roleEntity = _repository.Role.GetRoleById(id);
            if (roleEntity == null)
            {
                _logger.LogError($"Role with id: {id} hasn't been found in db.");
                return NotFound();
            }

            _mapper.Map(role, roleEntity);
            _repository.Role.UpdateRole(roleEntity);
            _repository.Save();

            return NoContent();
        }

        // DELETE api/role/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(Guid id)
        {
            var role = _repository.Role.GetRoleById(id);
            if (role == null)
            {
                _logger.LogError($"Role with id: {id} hasn't been found in db");
                return NotFound();
            }

            _repository.Role.DeleteRole(role);
            _repository.Save();

            return NoContent();
        }
    }
}