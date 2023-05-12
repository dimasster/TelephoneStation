using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Account.LogIn;
using TelephoneStationBLL.MediatR.Account.SignUp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        // GET api/<Authorization>/log_in
        [HttpPost("log_in")]
        public async Task<IActionResult> LogIn([FromBody] AccountDTO account)
        {
            return HandleResult(await Mediator.Send(new LogInAccountQuery(account)));
        }

        // POST api/<Authorization>/sign_up
        [HttpPost("sign_up")]
        public async Task<IActionResult> SignUp([FromBody] AccountDTO account)
        {
            return HandleResult(await Mediator.Send(new SignUpAccountCommand(account)));
        }

        // DELETE api/<Authorization>/5
        [HttpDelete("{id}")]
        public void DeleteAccount(int id)
        {
        }
    }
}
