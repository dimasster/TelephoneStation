using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.MediatR.Subscriptions.GetByUserId;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : BaseApiController
    {
        // GET api/<SubscriptionsController>/5
        [HttpGet("{user_id}")]
        public async Task<IActionResult> Get(int user_id)
        {
            return HandleResult(await Mediator.Send(new GetSubscriptionByUserIdQuery(user_id)));
        }

        // POST api/<SubscriptionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubscriptionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubscriptionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
