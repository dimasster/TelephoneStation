using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.MediatR.SavedUsers.GetByUserId;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedUserController : BaseApiController
    {
        // GET api/<SavedUsersController>/5
        [HttpGet("{user_id}")]
        public async Task<IActionResult> Get(int user_id)
        {
            return HandleResult(await Mediator.Send(new GetSavedUsersByUserIdQuery(user_id)));
        }

        // POST api/<SavedUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SavedUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SavedUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
