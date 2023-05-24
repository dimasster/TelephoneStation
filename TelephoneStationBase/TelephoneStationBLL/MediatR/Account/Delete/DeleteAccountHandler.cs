using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.Services;
using TelephoneStationDAL.Enums;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Account.Delete;

public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, Result<string>>
{
    private readonly IRepositoryWrapper _repository;
    private readonly AuthorizationService _authorizationService;

    public DeleteAccountHandler(IRepositoryWrapper repository, AuthorizationService authorizationService)
    {
        _repository = repository;
        _authorizationService = authorizationService;
    }

    public async Task<Result<string>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.AccountRepo.GetSingleOrDefaultAsync(
            predicate: acc => acc.UserId == request.user_id,
            include: a => a.Include(al => al.User));

        if (account == null)
            return Result.Fail($"There is no account with this id: {request.user_id}");

        if (account.User == null)
        {
            _repository.AccountRepo.Delete(account);
            return Result.Fail("There is no user attached to this account");
        }

        if (!_authorizationService.VerifyUser(request.verification))
            return Result.Fail("You can`t delete this account");

        //todo replace to get userrole api
        var user = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.verification.Id);
        if (user == null) 
            return Result.Fail($"There is no user eith id {request.verification.Id}");
        var userRole = user.Role;

        if(request.user_id == request.verification.Id || userRole == UserRole.Admin)
        {
            _repository.UserRepo.Delete(account.User);
            _repository.AccountRepo.Delete(account);

            return Result.Ok("Account was successfully deleted");
        }

        return Result.Fail("You can`t delete this account");
    }
}
