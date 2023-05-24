using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Ballance.Get;

public record GetBallanceByUserIdQuery(int user_id, VerificationDTO verification) : IRequest<Result<double>>;
