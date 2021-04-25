using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pro.Universal.Common.Services.Interfaces;
using Pro.Universal.Data.Repositories.Interfaces;

namespace Pro.Universal.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repositoryWrapper;

        public TestController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Test logger
            //_logger.LogInfo("Here is info message from the controller.");
            //_logger.LogDebug("Here is debug message from the controller.");
            //_logger.LogWarn("Here is warn message from the controller.");
            //_logger.LogError("Here is error message from the controller.");

            // Test repositories
            //var roles = _repositoryWrapper.Role.FindAll().Include(c => c.Customers);
            //var customers = _repositoryWrapper.Customer.FindAll();
            //var user1 = _repositoryWrapper.Customer.FindByCondition(x => x.Role.Id == roles.First().Id);

            return new string[] { "one", "two", "three" };
        }
    }
}