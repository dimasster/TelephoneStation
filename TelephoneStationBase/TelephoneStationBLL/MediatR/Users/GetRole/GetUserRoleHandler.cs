using FluentResults;
using MediatR;
using TelephoneStationDAL.Enums;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Users.GetRole;

public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, Result<UserRole>>
{
    readonly IRepositoryWrapper _repository;

    public GetUserRoleHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<UserRole>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
    {
        //todo add verification
        var user = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.user_id);
        if (user == null)
            return Result.Fail($"There is no user with id {request.user_id}");

        return Result.Ok(user.Role);
    }
}
