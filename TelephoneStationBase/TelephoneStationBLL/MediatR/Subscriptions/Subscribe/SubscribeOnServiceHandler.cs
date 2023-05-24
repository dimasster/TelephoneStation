using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationBLL.MediatR.Subscriptions.Resubscribe;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Subscriptions.Subscribe;

public class SubscribeOnServiceHandler : IRequestHandler<SubscribeOnServiceCommand, Result<SubscriptionDTO>>
{
    readonly IMediator _mediator;
    readonly IMapper _mapper;
    readonly IRepositoryWrapper _repository;

    public SubscribeOnServiceHandler(IMediator mediator, IMapper mapper, IRepositoryWrapper repository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<SubscriptionDTO>> Handle(SubscribeOnServiceCommand request, CancellationToken cancellationToken)
    {
        //todo add verification
        //todo add validation
        if (request.subscription.User == null || request.subscription.Service == null)
            return Result.Fail("User and Service properties of Subscription cannot be empty");

        var requestSubscription = _mapper.Map<Subscription>(request.subscription);
        var existingSubscription = await _repository.SubscriptionRepo
            .GetSingleOrDefaultAsync(s => s.UserId == request.subscription.User.Id);

        //if user don`t have subscription now => create new
        if (existingSubscription == null)
        {
            var createdSubscriptionId = (await _repository.SubscriptionRepo.CreateAsync(requestSubscription)).Id;
            var createdSubscription = await _repository.SubscriptionRepo
                .GetSingleOrDefaultAsync(
                    predicate: s => s.Id == createdSubscriptionId,
                    include: s => s.Include(sl=>sl.Service).Include(sl=>sl.User));
            if (createdSubscription == null)
                return Result.Fail("Fail during subscription creation");

            var receiptDto = new ReceiptDTO()
            {
                Date = createdSubscription.SubscriptionStartDate,
                Price = createdSubscription.Service.SubscriptionCost,
                IsBought = false,
                Type = "subscription receipt",
                ItemId = createdSubscription.ServiceId
            };
            //todo call CreateReceipt api

            var createdSubscriptionDto = _mapper.Map<SubscriptionDTO>(createdSubscription);

            return Result.Ok(createdSubscriptionDto);
        }
        //if user allready have a subscription => 
        else
        {
            //=> if the subscription is on same service => prolongate existing subscription
            if (existingSubscription.ServiceId == request.subscription.Service.Id)
            {
                var userId = request.subscription.User.Id;
                var newDate = request.subscription.SubscriptionEndDate;
                var subscriptionResponce = await _mediator.Send(new ResubscribeOnServiceCommand(userId, newDate, request.verification));
                return subscriptionResponce;
            }
            //=> else finish existing subscription and add new one
            else
            {
                _repository.SubscriptionRepo.Delete(existingSubscription);
                var subscriptionDto = await this.Handle(request, cancellationToken);
                return subscriptionDto;
            }
        }
    }
}
