using Microsoft.AspNetCore.Mvc;
using Streetcode.WebApi.Controllers;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Receipts.Create;
using TelephoneStationBLL.MediatR.Receipts.GetAll;
using TelephoneStationBLL.MediatR.Receipts.GetByUserId;
using TelephoneStationBLL.MediatR.Receipts.GetTotalDebt;
using TelephoneStationBLL.MediatR.Receipts.Pay;

namespace TelephoneStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : BaseApiController
    {
        // GET: api/Receipt/all
        [HttpGet("all")]
        public async Task<IActionResult> Get([FromHeader] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetAllReceiptsQuery()));
        }

        // GET api/Receipt?user_id=1
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int user_id, [FromHeader] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetReceiptsByUserIdQuery(user_id)));
        }

        // GET api/Receipt/debt?user_id=1
        [HttpGet("debt")]
        public async Task<ActionResult> GetTotalDebt([FromQuery] int user_id, [FromHeader] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new GetTotalDebtQuery(user_id, verification)));
        }

        // POST api/Receipt
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Tuple<ReceiptDTO, VerificationDTO> request)
        {
            return HandleResult(await Mediator.Send(new CreateReceiptCommand(request.Item1, request.Item2)));
        }

        // Patch api/Receipt?id=1
        [HttpPatch]
        public async Task<ActionResult> Pay([FromQuery] int id, [FromBody] VerificationDTO verification)
        {
            return HandleResult(await Mediator.Send(new PayReceiptCommand(id, verification)));
        }
    }
}
