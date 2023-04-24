using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.MediatR.Calls.GetAll;
using TelephoneStationBLL.MediatR.Calls.GetAllByUserId;

namespace TelephoneStationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CallController : BaseApiController
{
    // GET: api/<CallsController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return HandleResult(await Mediator.Send(new GetAllCallsQuery()));
    }

    // GET api/<CallsController>/5
    [HttpGet("{user_id}")]
    public async Task<IActionResult> Get(int user_id)
    {
        return HandleResult(await Mediator.Send(new GetAllCallsByUserIdQuery(user_id)));
    }

    // POST api/<CallsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CallsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CallsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
