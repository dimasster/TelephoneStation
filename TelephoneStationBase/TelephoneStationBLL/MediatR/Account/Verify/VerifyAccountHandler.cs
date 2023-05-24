using FluentResults;
using MediatR;
using TelephoneStationBLL.Services;
using TelephoneStationDAL.Enums;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Account.Verify;

public class VerifyAccountHandler : IRequestHandler<VerifyAccountQuery, Result<int>>
{
    readonly AuthorizationService _authorizationService;
    readonly IRepositoryWrapper _repository;

    public VerifyAccountHandler(AuthorizationService authorizationService, IRepositoryWrapper repository)
    {
        _authorizationService = authorizationService;
        _repository = repository;
    }

    public async Task<Result<int>> Handle(VerifyAccountQuery request, CancellationToken cancellationToken)
    {
        if(_authorizationService.VerifyUser(request.verification))
        {
            /*replace with get role api*/
            var user = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.verification.Id);

            if (user == null)
                return Result.Fail("There is no such user in system");

            if (user.Role == UserRole.Admin)
                return Result.Ok(2);

            return Result.Ok(1);
        }

        return Result.Ok(0);    
    }
}
