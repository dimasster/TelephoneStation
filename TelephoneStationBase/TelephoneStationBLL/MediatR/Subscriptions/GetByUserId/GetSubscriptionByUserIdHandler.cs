using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationBLL.MediatR.Subscriptions.GetByUserId;

public class GetSubscriptionByUserIdHandler : IRequestHandler<GetSubscriptionByUserIdQuery, Result<SubscriptionDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetSubscriptionByUserIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<SubscriptionDTO>> Handle(GetSubscriptionByUserIdQuery request, CancellationToken cancellationToken)
    {
        var subscription = await _repositoryWrapper
            .SubscriptionRepo
            .GetSingleOrDefaultAsync(
                predicate: s => s.UserId == request.user_id,
                include: s => s.Include(sl => sl.User).Include(sl => sl.Service));

        if (subscription is null)
        {
            return Result.Fail(new Error($"Cannot find any subscription for user"));
        }

        var subscriptionDto = _mapper.Map<SubscriptionDTO>(subscription);
        return Result.Ok(subscriptionDto);
    }
}