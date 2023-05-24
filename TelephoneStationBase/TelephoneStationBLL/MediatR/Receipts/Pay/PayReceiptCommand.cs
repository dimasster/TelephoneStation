using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Receipts.Pay;

public record PayReceiptCommand(int id, VerificationDTO verification) : IRequest<Result<string>>;