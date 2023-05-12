using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Services.GetAll;
using TelephoneStationBLL.MediatR.Services.Post;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseApiController
    {
        // GET api/<ServicesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await Mediator.Send(new GetAllServicesQuery()));
        }

        // POST api/<ServicesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceDTO service)
        {
            return HandleResult(await Mediator.Send(new PostServiceCommand(service)));
        }

        // PUT api/<ServicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
