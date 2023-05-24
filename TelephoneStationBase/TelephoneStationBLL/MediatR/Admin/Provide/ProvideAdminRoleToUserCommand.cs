using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Admin.Provide;

public record ProvideAdminRoleToUserCommand(int user_id, VerificationDTO verification) : IRequest<Result<string>>;
