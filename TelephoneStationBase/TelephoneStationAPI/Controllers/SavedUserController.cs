using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.SavedUsers.Add;
using TelephoneStationBLL.MediatR.SavedUsers.GetByUserId;
using TelephoneStationBLL.MediatR.SavedUsers.Remove;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedUserController : BaseApiController
    {
        // GET api/SavedUser?user_id=1
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int user_id, [FromHeader] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetSavedUsersByUserIdQuery(user_id)));
        }

        // POST api/SavedUser
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Tuple<SavedUserRequestDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new AddSavedUserCommand(request.Item1, request.Item2)));
        }

        // DELETE api/SavedUser?user_id=1
        [HttpDelete]
        public async Task<ActionResult> Remove([FromQuery] int target_id, [FromBody] Tuple<int, VerificationDTO> request)
        {
            var savedUserRequest = new SavedUserRequestDTO { UsertId = request.Item1, TargetId = target_id };
            return HandleResult(await Mediator.Send(new RemoveSavedUserCommand(savedUserRequest, request.Item2)));
        }
    }
}
