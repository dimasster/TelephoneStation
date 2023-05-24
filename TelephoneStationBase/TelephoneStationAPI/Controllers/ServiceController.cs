using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Services.Delete;
using TelephoneStationBLL.MediatR.Services.Edit;
using TelephoneStationBLL.MediatR.Services.GetAll;
using TelephoneStationBLL.MediatR.Services.GetById;
using TelephoneStationBLL.MediatR.Services.Post;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseApiController
    {
        // GET api/Service/all
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await Mediator.Send(new GetAllServicesQuery()));
        }

        // GET api/Service?id=1
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            return HandleResult(await Mediator.Send(new GetServiceByIdQuery(id)));
        }

        // POST api/Service
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tuple<ServiceDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new PostServiceCommand(request.Item1)));
        }

        // PUT api/Service
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] Tuple<ServiceDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new EditServiceCommand(request.Item1, request.Item2)));
        }

        // DELETE api/Service?id=1
        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new DeleteServiceCommand(id, verification)));
        }
    }
}
