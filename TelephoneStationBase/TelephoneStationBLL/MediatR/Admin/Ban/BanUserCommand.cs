using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Admin.Ban;

public record BanUserCommand(int user_id, VerificationDTO verification) : IRequest<Result<string>>;
