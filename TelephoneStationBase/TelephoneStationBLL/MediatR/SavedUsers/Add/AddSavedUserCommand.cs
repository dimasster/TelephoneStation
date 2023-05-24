using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.SavedUsers.Add;

public record AddSavedUserCommand(SavedUserRequestDTO savedUser, VerificationDTO verification) : IRequest<Result<UserDTO>>;