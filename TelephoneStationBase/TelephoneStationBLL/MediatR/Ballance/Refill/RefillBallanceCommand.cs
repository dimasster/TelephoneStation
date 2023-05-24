using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Ballance.Refill;

public record RefillBallanceCommand(TransactionDTO refill, VerificationDTO verification) : IRequest<Result<string>>;