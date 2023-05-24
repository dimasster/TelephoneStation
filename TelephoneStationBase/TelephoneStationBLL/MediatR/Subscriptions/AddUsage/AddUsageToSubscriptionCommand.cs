using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Subscriptions.AddUsage;

public record AddUsageToSubscriptionCommand(int user_id, int minutes, VerificationDTO verification) : IRequest<Result<SubscriptionDTO>>;