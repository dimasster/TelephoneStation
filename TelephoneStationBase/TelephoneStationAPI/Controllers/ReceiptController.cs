using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.MediatR.Receipt.GetAll;
using TelephoneStationBLL.MediatR.Receipts.GetByUserId;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : BaseApiController
    {
        // GET: api/<ReceiptsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await Mediator.Send(new GetAllReceiptsQuery()));
        }

        // GET api/<ReceiptsController>/5
        [HttpGet("{user_id}")]
        public async Task<IActionResult> Get(int user_id)
        {
            return HandleResult(await Mediator.Send(new GetReceiptsByUserIdQuery(user_id)));
        }

        // POST api/<ReceiptsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReceiptsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceiptsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
