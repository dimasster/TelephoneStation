using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Admin.Ban;
using TelephoneStationBLL.MediatR.Admin.Provide;
using TelephoneStationBLL.MediatR.Admin.Remove;
using TelephoneStationBLL.MediatR.Admin.Unban;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseApiController
    {
        // Patch api/Admin/bun?user_id=1
        [HttpPatch("bun")]
        public async Task<ActionResult> Ban([FromQuery] int user_id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new BanUserCommand(user_id, verification)));
        }

        // Patch api/Admin/unbun?user_id=1
        [HttpPatch("unbun")]
        public async Task<ActionResult> Unban([FromQuery] int user_id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new UnbanUserCommand(user_id, verification)));
        }

        // Patch api/Admin/provide?user_id=1
        [HttpPatch("provide")]
        public async Task<ActionResult> Provide([FromQuery] int user_id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new ProvideAdminRoleToUserCommand(user_id, verification)));
        }

        // Patch api/Admin/remove?user_id=1
        [HttpPatch("remove")]
        public async Task<ActionResult> Remove([FromQuery] int user_id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new RemoveAdminRoleFromUserCommand(user_id, verification)));
        }
    }
}
