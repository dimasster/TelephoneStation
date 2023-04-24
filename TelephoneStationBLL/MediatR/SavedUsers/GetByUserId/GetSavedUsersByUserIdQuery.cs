using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.SavedUsers.GetByUserId;

public record GetSavedUsersByUserIdQuery(int user_id) : IRequest<Result<IEnumerable<UserDTO>>>;