using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Subscriptions.Subscribe;

public record SubscribeOnServiceCommand(SubscriptionDTO subscription, VerificationDTO verification) : IRequest<Result<SubscriptionDTO>>;