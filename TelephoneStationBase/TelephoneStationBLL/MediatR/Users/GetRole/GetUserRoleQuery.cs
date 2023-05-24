using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Enums;

namespace TelephoneStationBLL.MediatR.Users.GetRole;

public record GetUserRoleQuery(int user_id, VerificationDTO verification) : IRequest<Result<UserRole>>;