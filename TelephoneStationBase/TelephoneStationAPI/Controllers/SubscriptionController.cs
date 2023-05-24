using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Subscriptions.AddUsage;
using TelephoneStationBLL.MediatR.Subscriptions.GetByUserId;
using TelephoneStationBLL.MediatR.Subscriptions.Resubscribe;
using TelephoneStationBLL.MediatR.Subscriptions.Subscribe;
using TelephoneStationBLL.MediatR.Subscriptions.Unsubscribe;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : BaseApiController
    {
        // GET api/Subscription?user_id=1
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int user_id, [FromHeader] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetSubscriptionByUserIdQuery(user_id)));
        }

        // POST api/Subscription
        [HttpPost]
        public async Task<ActionResult> Subscribe([FromBody] Tuple<SubscriptionDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new SubscribeOnServiceCommand(request.Item1, request.Item2)));
        }

        // PUT api/Subscription
        [HttpPut]
        public async Task<ActionResult> Resubscribe([FromQuery] int user_id, [FromBody] Tuple<DateTime, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new ResubscribeOnServiceCommand(user_id, request.Item1, request.Item2)));
        }

        // PATCH api/Subscription?id=1
        [HttpPatch]
        public async Task<ActionResult> AddUsage([FromQuery] int user_id, [FromBody] Tuple<int, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new AddUsageToSubscriptionCommand(user_id, request.Item1, request.Item2)));
        }

        // DELETE api/Subscription?user_id=1
        [HttpDelete]
        public async Task<ActionResult> Unsubscribe([FromQuery] int user_id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new UnsubscribeFromServiceCommand(user_id, verification)));
        }
    }
}
