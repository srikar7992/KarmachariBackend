using BusinessEntityModels;
using Karmachari.Business.Contracts.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarmachariApi.Controllers.Karmchari.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private protected readonly LoggerImplementation.ILogger _logger;
        private protected readonly IUserBusinessContract userBusinessContract;

        public UsersController(LoggerImplementation.ILogger logger, IUserBusinessContract userBusinessContract)
        {
            _logger = logger;
            this.userBusinessContract = userBusinessContract;
        }

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> Get()
        {
            return userBusinessContract.GetAll();
        }

    }
}
