using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Subscriptions.GetByUserId;

public record GetSubscriptionByUserIdQuery(int user_id) : IRequest<Result<SubscriptionDTO>>;