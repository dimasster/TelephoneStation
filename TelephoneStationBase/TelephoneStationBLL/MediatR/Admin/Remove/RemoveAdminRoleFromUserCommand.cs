using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Admin.Remove;

public record RemoveAdminRoleFromUserCommand(int user_id, VerificationDTO verification) : IRequest<Result<string>>;
