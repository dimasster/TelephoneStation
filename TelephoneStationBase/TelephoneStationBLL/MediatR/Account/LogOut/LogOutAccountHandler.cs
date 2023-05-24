using FluentResults;
using MediatR;
using TelephoneStationBLL.Services;

namespace TelephoneStationBLL.MediatR.Account.LogOut;

public class LogOutAccountHandler : IRequestHandler<LogOutAccountQuery, Result<string>>
{
    private readonly AuthorizationService _authorizationService;

    public LogOutAccountHandler(AuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task<Result<string>> Handle(LogOutAccountQuery request, CancellationToken cancellationToken)
    {
        if (_authorizationService.RemoveActiveUser(request.user_id, request.verification))
            return Result.Ok("You successfully logged out");

        return Result.Fail(new Error($"Cunnot log out"));
    }
}
