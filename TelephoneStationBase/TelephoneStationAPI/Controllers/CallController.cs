using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Calls.Create;
using TelephoneStationBLL.MediatR.Calls.Finish;
using TelephoneStationBLL.MediatR.Calls.GetAll;
using TelephoneStationBLL.MediatR.Calls.GetAllByUserId;
using TelephoneStationBLL.MediatR.Calls.GetById;

namespace TelephoneStationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CallController : BaseApiController
{
    // GET: api/Call/all
    [HttpGet("all")]
    public async Task<IActionResult> Get([FromHeader] VerificationDTO verification)
    {
        return HandleResult(await Mediator.Send(new GetAllCallsQuery(verification)));
    }

    // GET api/Call?user_id=1
    [HttpGet]
    public async Task<IActionResult> GetByUserId([FromQuery] int user_id, [FromHeader] VerificationDTO verification)
    {
        return HandleResult(await Mediator.Send(new GetAllCallsByUserIdQuery(user_id, verification)));
    }

    // GET api/Call/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, [FromHeader] VerificationDTO verification)
    {
        return HandleResult(await Mediator.Send(new GetCallByIdQuery(id, verification)));
    }

    // POST api/Call
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Tuple<CallCreateDTO, VerificationDTO> request)
    {
        return HandleResult(await Mediator.Send(new CreateCallCommand(request.Item1, request.Item2)));
    }

    // PATCH api/Call?id=1
    [HttpPatch]
    public async Task<ActionResult> Finish([FromQuery] int id, [FromBody] VerificationDTO verification)
    {
        return HandleResult(await Mediator.Send(new FinishCallCommand(id, verification)));
    }
}
