using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Users.Edit;
using TelephoneStationBLL.MediatR.Users.GetAll;
using TelephoneStationBLL.MediatR.Users.GetById;
using TelephoneStationBLL.MediatR.Users.GetRole;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        // GET: api/User/all
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await Mediator.Send(new GetAllUsersQuery()));
        }

        // GET api/User?user_id=1
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int user_id, [FromHeader] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetUserByIdQuery(user_id)));
        }

        // GET api/User/role?user_id=1
        [HttpGet("role")]
        public async Task<ActionResult> GetRole([FromHeader] int user_id, [FromQuery] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetUserRoleQuery(user_id, verification)));
        }

        // PATCH api/User
        [HttpPatch]
        public async Task<ActionResult> Edit([FromBody] Tuple<UserDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new EditUserCommand(request.Item1, request.Item2)));
        }
    }
}
