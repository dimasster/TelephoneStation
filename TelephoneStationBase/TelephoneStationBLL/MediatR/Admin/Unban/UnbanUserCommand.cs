using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Admin.Unban;

public record UnbanUserCommand(int user_id, VerificationDTO verification) : IRequest<Result<string>>;
