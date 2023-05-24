using FluentResults;
using MediatR;
using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.MediatR.Subscriptions.Resubscribe;

public record ResubscribeOnServiceCommand(int user_id, DateTime date, VerificationDTO verification) : IRequest<Result<SubscriptionDTO>>;