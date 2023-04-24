using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Receipts.GetByUserId;

public record GetReceiptsByUserIdQuery(int user_id) : IRequest<Result<IEnumerable<ReceiptDTO>>>;