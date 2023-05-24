using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Ballance.Refill;

public class RefillBallanceHandler : IRequestHandler<RefillBallanceCommand, Result<string>>
{
    readonly IRepositoryWrapper _repository;

    public RefillBallanceHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(RefillBallanceCommand request, CancellationToken cancellationToken)
    {
        //todo verify personal permission
        var user = await _repository.UserRepo.GetSingleOrDefaultAsync(u => u.Id == request.refill.UserId);
        if (user == null)
            return Result.Fail($"There is no user with id: {request.refill.UserId}");

        if (request.refill.Value <= 0)
            return Result.Fail("The value of purchise can`t be less or equal than 0");

        user.Ballance += request.refill.Value;
        var updatedBallance = _repository.UserRepo.Update(user).Entity.Ballance;

        return Result.Ok($"You successfully purchise a receipt. \t" +
            $"You have {updatedBallance}$ now");
    }
}
