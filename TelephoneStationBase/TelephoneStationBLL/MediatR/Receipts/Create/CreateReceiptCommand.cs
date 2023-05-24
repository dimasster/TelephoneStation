using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Receipts.Create;

public record CreateReceiptCommand(ReceiptDTO receipt, VerificationDTO verification) : IRequest<Result<ReceiptDTO>>;
