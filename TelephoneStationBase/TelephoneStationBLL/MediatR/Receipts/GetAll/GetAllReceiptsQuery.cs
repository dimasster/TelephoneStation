using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Receipts.GetAll;

public record GetAllReceiptsQuery : IRequest<Result<IEnumerable<ReceiptDTO>>>;