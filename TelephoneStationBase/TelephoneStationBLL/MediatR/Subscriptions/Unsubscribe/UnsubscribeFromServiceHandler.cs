using FluentResults;
using MediatR;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Subscriptions.Unsubscribe;

public class UnsubscribeFromServiceHandler : IRequestHandler<UnsubscribeFromServiceCommand, Result<string>>
{
    readonly IRepositoryWrapper _repository;

    public UnsubscribeFromServiceHandler(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(UnsubscribeFromServiceCommand request, CancellationToken cancellationToken)
    {
        //todo add verification
        var subscription = await _repository.SubscriptionRepo.GetSingleOrDefaultAsync(s => s.UserId == request.user_id);
        if (subscription == null)
            return Result.Fail($"There is no subscription in user with id {request.user_id}");

        _repository.SubscriptionRepo.Delete(subscription);

        return Result.Ok("You successfully unsubscribe from service");
    }
}
