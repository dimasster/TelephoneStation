using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Users.Edit;

public record EditUserCommand(UserDTO user, VerificationDTO verification) : IRequest<Result<UserDTO>>;