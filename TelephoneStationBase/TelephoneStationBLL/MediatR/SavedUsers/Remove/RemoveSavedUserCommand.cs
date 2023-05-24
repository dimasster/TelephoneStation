using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.SavedUsers.Remove;

public record RemoveSavedUserCommand(SavedUserRequestDTO savedUser, VerificationDTO verification) : IRequest<Result<string>>;