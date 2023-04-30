using Data.DTOs;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService) 
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult<AuthenticationResponse> Post([FromBody] UserCreation userCreation) 
        {
            var token = accountService.CreateAccount(userCreation);
            if (token == null) {
                return BadRequest();
            }
            return token;
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationResponse> Post(AccountCredentials accountCredentials)
        {
            var token = accountService.LoginAccount(accountCredentials);
            if (token == null)
            {
                return BadRequest("Could not log in");
            }

            return token;
        }

        [HttpGet]
        public ActionResult<List<UserResponse>> GetUsers()
        {
            var listUsers = accountService.GetAcounts();
            
            if(listUsers == null) 
            {
                return BadRequest();
            }

            return listUsers;
        }

        [HttpGet("renew")]
        public ActionResult<AuthenticationResponse> GetRefreshToken()
        {
            var updatedToken = accountService.GetRefreshToken();
            if(updatedToken == null) 
            {
                return BadRequest();
            }

            return updatedToken;
        }
    }
}
