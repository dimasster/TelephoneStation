using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Ballance.Purchise;

public class PurchiseHandler : IRequestHandler<PurchiseCommand, Result<string>>
{
    readonly IRepositoryWrapper _repository;

    public PurchiseHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(PurchiseCommand request, CancellationToken cancellationToken)
    {
        //todo verify personal permission
        var user = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.purchise.UserId);
        if (user == null)
            return Result.Fail($"There is no user with id: {request.purchise.UserId}");

        if (request.purchise.Value <= 0)
            return Result.Fail("The value of purchise can`t be less or equal than 0");

        user.Ballance -= request.purchise.Value;
        var updatedBallance = _repository.UserRepo.Update(user).Entity.Ballance;

        return Result.Ok($"You successfully purchise a receipt. \t" +
            $"You have {updatedBallance}$ now");
    }
}
