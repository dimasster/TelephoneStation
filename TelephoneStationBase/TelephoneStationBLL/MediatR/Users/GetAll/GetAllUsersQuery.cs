using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Users.GetAll;

public record GetAllUsersQuery : IRequest<Result<IEnumerable<UserDTO>>>;