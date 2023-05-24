using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Subscriptions.Resubscribe;

public class ResubscribeOnServiceHandler : IRequestHandler<ResubscribeOnServiceCommand, Result<SubscriptionDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public ResubscribeOnServiceHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<SubscriptionDTO>> Handle(ResubscribeOnServiceCommand request, CancellationToken cancellationToken)
    {
        //todo add verification
        var subscription = await _repository.SubscriptionRepo.GetSingleOrDefaultAsync(s => s.UserId == request.user_id);
        if (subscription == null)
            return Result.Fail($"There is no subscription for user with id {request.user_id}");

        if (subscription.SubscriptionEndDate >= request.date)
            return Result.Fail($"If you want to prolongate subscription, new date mast be after current subscription end date");

        subscription.SubscriptionEndDate = request.date;

        var updatedSubscription = _repository.SubscriptionRepo.Update(subscription);

        var updatedSubscriptionDto = _mapper.Map<SubscriptionDTO>(updatedSubscription);

        return Result.Ok(updatedSubscriptionDto);
    }
}
