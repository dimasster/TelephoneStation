using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Receipt.GetAll;

public record GetAllReceiptsQuery : IRequest<Result<IEnumerable<ReceiptDTO>>>;