using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Ballance.Get;
using TelephoneStationBLL.MediatR.Ballance.Purchise;
using TelephoneStationBLL.MediatR.Ballance.Refill;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallanceController : BaseApiController
    {
        // Get api/Ballance/role?user_id=1
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int user_id, [FromHeader] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetBallanceByUserIdQuery(user_id, verification)));
        }

        // Patch api/Ballance/refill
        [HttpPatch("refill")]
        public async Task<ActionResult> Refill([FromBody] Tuple<TransactionDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new RefillBallanceCommand(request.Item1, request.Item2)));
        }

        // Patch api/Ballance/purchise
        [HttpPatch("purchise")]
        public async Task<ActionResult> Purchise([FromBody] Tuple<TransactionDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new PurchiseCommand(request.Item1, request.Item2)));
        }
    }
}
