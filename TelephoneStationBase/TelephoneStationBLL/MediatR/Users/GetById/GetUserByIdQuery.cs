using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Users.GetById;

public record GetUserByIdQuery(int id) : IRequest<Result<UserDTO>>;