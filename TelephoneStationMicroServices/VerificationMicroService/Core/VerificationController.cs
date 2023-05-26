using Microsoft.AspNetCore.Mvc;
using VerificationMicroService.Core.Mediatr.AddActiveUser;
using VerificationMicroService.Core.Mediatr.RemoveActiveUser;
using VerificationMicroService.Core.Mediatr.VerifyUser;

namespace VerificationMicroService.Core;
[Route("api/[controller]")]
[ApiController]
public class VerificationController : BaseApiController
{
    // POST api/Verification?id=1
    [HttpPost]
    public async Task<IActionResult> AddActiveUser([FromQuery] int id)
    {
        return HandleResult(await Mediator.Send(new AddActiveUserCommand(id)));
    }

    // Options api/Verification
    [HttpOptions]
    public async Task<ActionResult> VerifyUser([FromBody] Verification verification)
    {
        return HandleResult(await Mediator.Send(new VerifyUserQuery(verification)));
    }

    // DELETE api/Verification?id=1
    [HttpDelete]
    public async Task<IActionResult> RemoveActiveUser([FromQuery] int user_id, [FromBody] Verification verification)
    {
        return HandleResult(await Mediator.Send(new RemoveActiveUserCommand(user_id, verification)));
    }
}
