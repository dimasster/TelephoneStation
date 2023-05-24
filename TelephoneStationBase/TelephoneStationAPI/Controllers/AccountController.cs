using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Account.Delete;
using TelephoneStationBLL.MediatR.Account.LogIn;
using TelephoneStationBLL.MediatR.Account.LogOut;
using TelephoneStationBLL.MediatR.Account.SignUp;
using TelephoneStationBLL.MediatR.Account.Verify;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        // Get api/Account/log_in
        [HttpGet("log_in")]
        public async Task<IActionResult> LogIn([FromForm] AccountDTO account)
        {
            return HandleResult(await Mediator.Send(new LogInAccountQuery(account)));
        }

        // POST api/Account/sign_up
        [HttpPost("sign_up")]
        public async Task<IActionResult> SignUp([FromForm] AccountDTO account)
        {
            return HandleResult(await Mediator.Send(new SignUpAccountCommand(account)));
        }

        // Options api/Account/sign_up
        [HttpOptions("log_out")]
        public async Task<IActionResult> LogOut([FromBody] Tuple<int, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new LogOutAccountQuery(request.Item1, request.Item2)));
        }

        // Options api/Account/verify
        [HttpOptions("verify")]
        public async Task<ActionResult> Verify([FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new VerifyAccountQuery(verification)));
        }

        // DELETE api/Account?user_id=1
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int user_id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new DeleteAccountCommand(user_id, verification)));
        }
    }
}
