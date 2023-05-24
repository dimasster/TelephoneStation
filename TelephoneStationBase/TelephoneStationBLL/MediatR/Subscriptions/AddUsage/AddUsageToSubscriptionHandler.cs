using AutoMapper;
using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Subscriptions.AddUsage;

public class AddUsageToSubscriptionHandler : IRequestHandler<AddUsageToSubscriptionCommand, Result<SubscriptionDTO>>
{
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public AddUsageToSubscriptionHandler(IMapper mapper, IRepositoryWrapper repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<SubscriptionDTO>> Handle(AddUsageToSubscriptionCommand request, CancellationToken cancellationToken)
    {
        //todo add verification
        if (request.minutes <= 0)
            return Result.Fail("Invalid request. Minutes value cannot be less or equal to 0");

        var subscription = await _repository.SubscriptionRepo.GetSingleOrDefaultAsync(s => s.UserId == request.user_id);
        if (subscription == null)
            return Result.Fail($"There is no subscription for user with id {request.user_id}");

        subscription.MinuteOfUsage += request.minutes;
        var updatedSubscription = _repository.SubscriptionRepo.Update(subscription);
        var updatedSubscriptionDto = _mapper.Map<SubscriptionDTO>(updatedSubscription);

        return Result.Ok(updatedSubscriptionDto);
    }
}
